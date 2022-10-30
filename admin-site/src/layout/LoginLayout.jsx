import React from "react";
import wallpager from "../assets/login_page.webp";
import LoginRoute from "../routes/LoginRoute";

function LoginLayout() {
  return (
    <div style={{ backGroundImage: wallpager }}>
      <LoginRoute />
    </div>
  );
}

export default LoginLayout;
