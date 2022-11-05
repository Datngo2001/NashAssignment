import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import ConfirmModal from "../../../components/ConfirmModal";
import DataTable from "../../../components/DataTable/DataTable";
import useConfirmModal from "../../../hooks/useConfirmModal";
import useDataModal from "../../../hooks/useDataModal";
import useThrottle from "../../../hooks/useThrottle";
import {
  CREATE_PRODUCT_REQUEST,
  DELETE_PRODUCT_REQUEST,
  SEARCH_PRODUCT_REQUEST,
  UPDATE_PRODUCT_REQUEST,
} from "../../../store/reducer/product/productActionTypes";
import ProductModal from "./ProductModal/ProductModal";

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
  {
    id: "price",
    numeric: true,
    disablePadding: false,
    label: "Price",
  },
  {
    id: "createDate",
    numeric: true,
    disablePadding: false,
    label: "Create Date",
  },
  {
    id: "updateDate",
    numeric: true,
    disablePadding: false,
    label: "Update Date",
  },
];

function ProductPage() {
  const dispatch = useDispatch();
  const openConfirm = useConfirmModal();
  const { query, page, limit, count, products } = useSelector(
    (state) => state.product
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
      type: SEARCH_PRODUCT_REQUEST,
      payload: { query: "", page: 1, limit: limit },
    });
  }, []);

  const handlePageChange = (newPage) => {
    dispatch({
      type: SEARCH_PRODUCT_REQUEST,
      payload: { query: query, page: newPage, limit: limit },
    });
  };

  const handleLimitChange = (event) => {
    dispatch({
      type: SEARCH_PRODUCT_REQUEST,
      payload: { query: query, page: 1, limit: event.target.value },
    });
  };

  const handleSearch = useThrottle((e) => {
    dispatch({
      type: SEARCH_PRODUCT_REQUEST,
      payload: { query: e.target.value, page: 1, limit: limit },
    });
  }, 250);

  const handleCreate = () => {
    openCreateModal((data) => {
      dispatch({
        type: CREATE_PRODUCT_REQUEST,
        payload: data,
      });
    });
  };

  const handleEdit = (row) => {
    openUpdateModal(row, (data) => {
      dispatch({
        type: UPDATE_PRODUCT_REQUEST,
        payload: data,
      });
    });
  };

  const handleDelete = (product) => {
    openConfirm({
      message: `Do you want to delete product with id: ${product.id}?`,
      onYes: () => {
        dispatch({ type: DELETE_PRODUCT_REQUEST, payload: product.id });
      },
      onNO: () => {},
    });
  };

  return (
    <div>
      <DataTable
        title={"Products"}
        rows={products}
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
      <ProductModal
        open={dataModal.open}
        product={dataModal.data}
        action={dataModal.action}
        onSave={dataModal.handleSave}
        onClose={() => closeModal()}
      />
    </div>
  );
}

export default ProductPage;
