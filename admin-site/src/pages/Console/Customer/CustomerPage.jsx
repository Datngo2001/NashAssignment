import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import DataTable from "../../../components/DataTable/DataTable";
import useThrottle from "../../../hooks/useThrottle";
import { SEARCH_CUSTOMER_REQUEST } from "../../../store/reducer/customer/customerActionTypes";
import { DETAIL } from "../../../hooks/_dataAction";

const headCells = [
  {
    id: "id",
    numeric: false,
    disablePadding: false,
    label: "Id",
  },
  {
    id: "email",
    numeric: false,
    disablePadding: false,
    label: "Email",
  },
  {
    id: "userName",
    numeric: false,
    disablePadding: false,
    label: "UserName",
  },
  {
    id: "phoneNumber",
    numeric: false,
    disablePadding: false,
    label: "Phone Number",
  },
];

function CustomerPage() {
  const dispatch = useDispatch();
  const { query, page, limit, count, customers } = useSelector(
    (state) => state.customer
  );

  useEffect(() => {
    dispatch({
      type: SEARCH_CUSTOMER_REQUEST,
      payload: { query: "", page: 1, limit: limit },
    });
  }, []);

  const handlePageChange = (newPage) => {
    dispatch({
      type: SEARCH_CUSTOMER_REQUEST,
      payload: { query: query, page: newPage, limit: limit },
    });
  };

  const handleLimitChange = (event) => {
    dispatch({
      type: SEARCH_CUSTOMER_REQUEST,
      payload: { query: query, page: 1, limit: event.target.value },
    });
  };

  const handleSearch = useThrottle((e) => {
    dispatch({
      type: SEARCH_CUSTOMER_REQUEST,
      payload: { query: e.target.value, page: 1, limit: limit },
    });
  }, 250);

  return (
    <div>
      <DataTable
        allowActions={[DETAIL]}
        title={"Customers"}
        rows={customers}
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

export default CustomerPage;
