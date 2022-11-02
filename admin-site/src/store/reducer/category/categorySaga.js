import { takeLatest } from "redux-saga/effects";
import { CREATE_CATEGORY_REQUEST, SEARCH_CATEGORY_REQUEST } from "./categoryActionTypes";
import { createCategory, searchCategory } from "./categoryActions";

export default function* watchCategoryAction() {
    yield takeLatest(SEARCH_CATEGORY_REQUEST, searchCategory)
    yield takeLatest(CREATE_CATEGORY_REQUEST, createCategory)
}