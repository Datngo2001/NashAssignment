import { takeLatest } from "redux-saga/effects";
import { searchCustomer } from "./customerActions";
import { SEARCH_CUSTOMER_REQUEST } from "./customerActionTypes";

export default function* watchCustomerAction() {
    yield takeLatest(SEARCH_CUSTOMER_REQUEST, searchCustomer)
}