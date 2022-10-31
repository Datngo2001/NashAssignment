import React, { useEffect, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import DataTable from "../../../components/DataTable/DataTable";
import { SEARCH_PRODUCT_REQUEST } from "../../../store/reducer/product/productActionTypes";

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
];

function ProductPage() {
  const dispatch = useDispatch();
  const { query, page, limit, count, products } = useSelector(
    (state) => state.product
  );

  useEffect(() => {
    dispatch({
      type: SEARCH_PRODUCT_REQUEST,
      payload: { query: "", page: 1, limit: limit },
    });
  }, []);

  const handlePageChange = (event, newPage) => {
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

  const searchThrottle = useRef();
  const handleSearch = (e) => {
    if (searchThrottle.current) {
      clearTimeout(searchThrottle);
    }
    searchThrottle.current = setTimeout(() => {
      dispatch({
        type: SEARCH_PRODUCT_REQUEST,
        payload: { query: e.target.value, page: 1, limit: limit },
      });
    }, 250);
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
      />
    </div>
  );
}

export default ProductPage;
