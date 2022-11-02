import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import DataTable from "../../../components/DataTable/DataTable";
import CategoryModal from "./CategoryModal/CategoryModal";
import {
  SEARCH_CATEGORY_REQUEST,
  CREATE_CATEGORY_REQUEST,
  DELETE_CATEGORY_REQUEST,
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
    product: null,
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
      product: null,
      action: "create",
    });
  };

  const handleSave = (data) => {
    dispatch({
      type: CREATE_CATEGORY_REQUEST,
      payload: data,
    });
    setCategoryModal({
      open: false,
      product: null,
      action: "create",
    });
  };

  const handleClose = () => {
    setCategoryModal({
      open: false,
      product: null,
      action: "create",
    });
  };

  const handleDelete = (category) => {
    openNewConfirm(() => {
      dispatch({ type: DELETE_CATEGORY_REQUEST, payload: category.id });
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
        handleDeleteClick={handleDelete}
      />
      <CategoryModal
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
