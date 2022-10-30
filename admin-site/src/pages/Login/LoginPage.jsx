import { Button, ButtonGroup } from "@mui/material";
import React from "react";
import { useDispatch } from "react-redux";
import { SIGNIN_REQUEST } from "../../store/reducer/user/userActionTypes";

function LoginPage() {
  const dispatch = useDispatch();
  return (
    <div>
      <Button onClick={() => dispatch({ type: SIGNIN_REQUEST })}>Login</Button>
    </div>
  );
}

export default LoginPage;
