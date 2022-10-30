import { takeLatest } from "redux-saga/effects";
import { CHECK_USER_STATUS, SIGNIN_REQUEST, SIGNOUT_REQUEST } from "./userActionTypes";
import { signin, signout, checkUserStatus } from "./userActions";

export default function* watchUserAction() {
    yield takeLatest(SIGNIN_REQUEST, signin)
    yield takeLatest(SIGNOUT_REQUEST, signout)
    yield takeLatest(CHECK_USER_STATUS, checkUserStatus)
}