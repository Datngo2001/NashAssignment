import React from "react";
import { Route, Routes } from "react-router";
import CategoryPage from "../pages/Console/Category/CategoryPage";
import CustomerPage from "../pages/Console/Customer/CustomerPage";
import ProductPage from "../pages/Console/Product/ProductPage";

function ConsoleRoute() {
  return (
    <Routes>
      <Route index element={<ProductPage />} />
      <Route path="/product" element={<ProductPage />} />
      <Route path="/category" element={<CategoryPage />} />
      <Route path="/customer" element={<CustomerPage />} />
    </Routes>
  );
}

export default ConsoleRoute;
