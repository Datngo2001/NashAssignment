import { all } from "redux-saga/effects";
import watchProductAction from "./reducer/product/productSaga";
import watchUserAction from "./reducer/user/userSaga";
import watchCategoryAction from "./reducer/category/categorySaga";
import watchConfirmAction from "./reducer/confirm/confirmSaga";

export default function* rootSaga() {
    yield all([watchUserAction(), watchProductAction(), watchCategoryAction(), watchConfirmAction()])
}