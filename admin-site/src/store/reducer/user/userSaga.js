import { takeLatest } from "redux-saga/effects";
import { CHECK_USER_STATUS, SIGNIN_CALLBACK, SIGNIN_REQUEST, SIGNOUT_REQUEST } from "./userActionTypes";
import { signin, signout, checkUserStatus, signinCallback } from "./userActions";

export default function* watchUserAction() {
    yield takeLatest(SIGNIN_REQUEST, signin)
    yield takeLatest(SIGNOUT_REQUEST, signout)
    yield takeLatest(CHECK_USER_STATUS, checkUserStatus)
    yield takeLatest(SIGNIN_CALLBACK, signinCallback)
}