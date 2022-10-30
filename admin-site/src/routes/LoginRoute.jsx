import React from "react";
import LoginPage from "../pages/Login/LoginPage";
import CallbackPage from "../pages/Login/CallbackPage";
import { Route, Routes } from "react-router";

function LoginRoute() {
  return (
    <Routes>
      <Route index element={<LoginPage />} />
      <Route path="/callback" element={<CallbackPage />} />
    </Routes>
  );
}

export default LoginRoute;
