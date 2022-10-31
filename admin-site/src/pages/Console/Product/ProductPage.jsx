import React, { useEffect } from "react";
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
  const { products } = useSelector((state) => state.product);

  useEffect(() => {
    dispatch({
      type: SEARCH_PRODUCT_REQUEST,
      payload: { query: "", page: 1, limit: 10 },
    });
  }, []);

  console.log(products);

  return (
    <div>
      <DataTable title={"Products"} rows={products} headCells={headCells} />
    </div>
  );
}

export default ProductPage;
