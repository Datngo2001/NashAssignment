import { all } from "redux-saga/effects";
import watchProductAction from "./reducer/product/productSaga";
import watchUserAction from "./reducer/user/userSaga";

export default function* rootSaga() {
    yield all([watchUserAction(), watchProductAction()])
}