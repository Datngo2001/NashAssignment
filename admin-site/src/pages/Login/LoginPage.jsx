import { Button } from "@mui/material";
import React from "react";
import { useDispatch } from "react-redux";
import {
  SIGNIN_REQUEST,
  SIGNOUT_REQUEST,
} from "../../store/reducer/user/userActionTypes";

function LoginPage() {
  const dispatch = useDispatch();
  return (
    <div>
      <Button onClick={() => dispatch({ type: SIGNIN_REQUEST })}>Login</Button>
      <Button onClick={() => dispatch({ type: SIGNOUT_REQUEST })}>
        Logout
      </Button>
    </div>
  );
}

export default LoginPage;
