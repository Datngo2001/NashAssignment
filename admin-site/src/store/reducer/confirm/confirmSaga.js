import { takeLatest } from "redux-saga/effects";
import { closeAndTriggerCallBack } from "./confirmAction";
import { CLOSE_CONFIRM_DIALOG } from "./confirmActionTypes";

export default function* watchConfirmAction() {
    yield takeLatest(CLOSE_CONFIRM_DIALOG, closeAndTriggerCallBack)
}