import { takeLatest } from "redux-saga/effects";
import { SEARCH_PRODUCT_REQUEST } from "./productActionTypes";
import { searchProduct } from "./productActions";

export default function* watchProductAction() {
    yield takeLatest(SEARCH_PRODUCT_REQUEST, searchProduct)
}