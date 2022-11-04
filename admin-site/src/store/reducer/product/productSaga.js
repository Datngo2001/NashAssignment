import { takeLatest } from "redux-saga/effects";
import { CREATE_PRODUCT_REQUEST, DELETE_PRODUCT_REQUEST, SEARCH_PRODUCT_REQUEST, UPDATE_PRODUCT_REQUEST } from "./productActionTypes";
import { createProduct, removeProduct, searchProduct, updateProduct } from "./productActions";

export default function* watchProductAction() {
    yield takeLatest(SEARCH_PRODUCT_REQUEST, searchProduct)
    yield takeLatest(CREATE_PRODUCT_REQUEST, createProduct)
    yield takeLatest(UPDATE_PRODUCT_REQUEST, updateProduct)
    yield takeLatest(DELETE_PRODUCT_REQUEST, removeProduct)
}