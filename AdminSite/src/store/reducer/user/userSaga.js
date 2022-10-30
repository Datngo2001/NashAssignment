import { takeLatest } from "redux-saga/effects";
import { HANDLE_AUTH_STATE_CHANGE_REQUEST, REGISTER_REQUEST, SIGNIN_GOOGLE_REQUEST, SIGNIN_REQUEST, SIGNOUT_REQUEST } from "./userActionTypes";
import { register, signin, signinWithGoogle, signout, handleAuthStateChange } from "./userActions";

export default function* watchUserAction() {
    yield takeLatest(SIGNIN_REQUEST, signin)
    yield takeLatest(SIGNOUT_REQUEST, signout)
}