import React, { useEffect } from "react";
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
import useThrottle from "../../../hooks/useThrottle";
import useDataModal from "../../../hooks/useDataModal";

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
  const openConfirm = useConfirmModal();
  const { query, page, limit, count, categories } = useSelector(
    (state) => state.category
  );

  const {
    dataModal,
    openCreateModal,
    openDetailModal,
    openUpdateModal,
    closeModal,
  } = useDataModal();

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

  const handleSearch = useThrottle((e) => {
    dispatch({
      type: SEARCH_CATEGORY_REQUEST,
      payload: { query: e.target.value, page: 1, limit: limit },
    });
  }, 250);

  const handleDelete = (category) => {
    openConfirm({
      message: `Do you want to delete category ${category.id}`,
      onYes: () => {
        dispatch({ type: DELETE_CATEGORY_REQUEST, payload: category.id });
      },
      onNo: () => {},
    });
  };

  const handleEdit = (row) => {
    openUpdateModal(row, (data) => {
      dispatch({
        type: UPDATE_CATEGORY_REQUEST,
        payload: data,
      });
    });
  };

  const handleCreate = () => {
    openCreateModal((data) => {
      dispatch({
        type: CREATE_CATEGORY_REQUEST,
        payload: data,
      });
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
        handleAddClick={handleCreate}
        handleEditClick={handleEdit}
        handleDeleteClick={handleDelete}
        handleDetailClick={(row) => openDetailModal(row)}
      />
      <CategoryModal
        category={dataModal.data}
        open={dataModal.open}
        action={dataModal.action}
        onSave={dataModal.handleSave}
        onClose={() => closeModal()}
      />
    </div>
  );
}

export default CategoryPage;
