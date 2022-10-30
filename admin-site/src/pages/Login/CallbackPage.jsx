import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router";
import { SIGNIN_CALLBACK } from "../../store/reducer/user/userActionTypes";

function CallbackPage() {
  const navigate = useNavigate();
  const dispatch = useDispatch();
  const { user } = useSelector((state) => state.user);

  if (user) {
    navigate("/");
  } else {
    dispatch({ type: SIGNIN_CALLBACK });
  }

  return <div>CallbackPage</div>;
}

export default CallbackPage;
