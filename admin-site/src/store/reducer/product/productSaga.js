import { takeLatest } from "redux-saga/effects";
import { CREATE_PRODUCT_REQUEST, SEARCH_PRODUCT_REQUEST } from "./productActionTypes";
import { createProduct, searchProduct } from "./productActions";

export default function* watchProductAction() {
    yield takeLatest(SEARCH_PRODUCT_REQUEST, searchProduct)
    yield takeLatest(CREATE_PRODUCT_REQUEST, createProduct)
}