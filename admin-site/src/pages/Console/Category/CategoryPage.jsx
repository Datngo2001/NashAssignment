import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import DataTable from "../../../components/DataTable/DataTable";
import CategoryModal from "./CategoryModal/CategoryModal";
import {
  SEARCH_CATEGORY_REQUEST,
  CREATE_CATEGORY_REQUEST,
  DELETE_CATEGORY_REQUEST,
  UPDATE_CATEGORY_REQUEST,
} from "../../../store/reducer/category/categoryActionTypes";
import useConfirmModal from "../../../hooks/useConfirmModal";
import ConfirmModal from "../../../components/ConfirmModal";

const headCells = [
  {
    id: "id",
    numeric: true,
    disablePadding: false,
    label: "Id",
  },
  {
    id: "name",
    numeric: false,
    disablePadding: false,
    label: "Name",
  },
];

function CategoryPage() {
  const dispatch = useDispatch();
  const { query, page, limit, count, categories } = useSelector(
    (state) => state.category
  );
  const [categoryModal, setCategoryModal] = useState({
    open: false,
    category: null,
    action: "create",
  });
  const { confirm, openNewConfirm, onAnswer } = useConfirmModal({
    message: "Do you want to delete category ?",
  });

  useEffect(() => {
    dispatch({
      type: SEARCH_CATEGORY_REQUEST,
      payload: { query: "", page: 1, limit: limit },
    });
  }, []);

  const handlePageChange = (newPage) => {
    dispatch({
      type: SEARCH_CATEGORY_REQUEST,
      payload: { query: query, page: newPage, limit: limit },
    });
  };

  const handleLimitChange = (event) => {
    dispatch({
      type: SEARCH_CATEGORY_REQUEST,
      payload: { query: query, page: 1, limit: event.target.value },
    });
  };

  const searchThrottle = useRef();
  const handleSearch = (e) => {
    if (searchThrottle.current) {
      clearTimeout(searchThrottle);
    }
    searchThrottle.current = setTimeout(() => {
      dispatch({
        type: SEARCH_CATEGORY_REQUEST,
        payload: { query: e.target.value, page: 1, limit: limit },
      });
    }, 250);
  };

  const handleAddClick = () => {
    setCategoryModal({
      open: true,
      category: null,
      action: "create",
    });
  };

  const handleSave = (data, action) => {
    if (action === "edit") {
      dispatch({
        type: UPDATE_CATEGORY_REQUEST,
        payload: data,
      });
    } else if (action === "create") {
      dispatch({
        type: CREATE_CATEGORY_REQUEST,
        payload: data,
      });
    }

    setCategoryModal({
      open: false,
      category: null,
      action: "create",
    });
  };

  const handleClose = () => {
    setCategoryModal({
      open: false,
      category: null,
      action: "",
    });
  };

  const handleDelete = (category) => {
    openNewConfirm(() => {
      dispatch({ type: DELETE_CATEGORY_REQUEST, payload: category.id });
    });
  };

  const handleDetailClick = (row) => {
    setCategoryModal({
      open: true,
      category: row,
      action: "detail",
    });
  };

  const handleEdit = (row) => {
    setCategoryModal({
      open: true,
      category: row,
      action: "edit",
    });
  };

  return (
    <div>
      <DataTable
        title={"Categories"}
        rows={categories}
        headCells={headCells}
        query={query}
        page={page}
        count={count}
        limit={limit}
        handleChangePage={handlePageChange}
        handleChangeRowsPerPage={handleLimitChange}
        handleSearch={handleSearch}
        handleAddClick={handleAddClick}
        handleEditClick={handleEdit}
        handleDeleteClick={handleDelete}
        handleDetailClick={handleDetailClick}
      />
      <CategoryModal
        category={categoryModal.category}
        open={categoryModal.open}
        action={categoryModal.action}
        onSave={handleSave}
        onClose={handleClose}
      />
      <ConfirmModal
        open={confirm.open}
        message={confirm.message}
        onAnswer={onAnswer}
      />
    </div>
  );
}

export default CategoryPage;
