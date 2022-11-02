import { takeLatest } from "redux-saga/effects";
import { CREATE_CATEGORY_REQUEST, DELETE_CATEGORY_REQUEST, SEARCH_CATEGORY_REQUEST } from "./categoryActionTypes";
import { createCategory, removeCategory, searchCategory } from "./categoryActions";

export default function* watchCategoryAction() {
    yield takeLatest(SEARCH_CATEGORY_REQUEST, searchCategory)
    yield takeLatest(CREATE_CATEGORY_REQUEST, createCategory)
    yield takeLatest(DELETE_CATEGORY_REQUEST, removeCategory)
}