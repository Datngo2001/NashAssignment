import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { useNavigate } from "react-router";
import { SIGNIN_CALLBACK } from "../../store/reducer/user/userActionTypes";

function CallbackPage() {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch({ type: SIGNIN_CALLBACK });
    navigate("/");
  }, []);

  return <div>CallbackPage</div>;
}

export default CallbackPage;
