import { put } from 'redux-saga/effects'
import { deleteProduct, getProducts, postProduct, putProduct } from '../../../api/product'
import { CREATE_PRODUCT_FAILURE, CREATE_PRODUCT_SUCCESS, DELETE_PRODUCT_FAILURE, DELETE_PRODUCT_SUCCESS, SEARCH_PRODUCT_FAILURE, SEARCH_PRODUCT_SUCCESS, UPDATE_PRODUCT_FAILURE, UPDATE_PRODUCT_SUCCESS } from './productActionTypes'

export function* searchProduct({ payload }) {
    try {
        var res = yield getProducts(payload.query, payload.page, payload.limit)
        yield put({
            type: SEARCH_PRODUCT_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: SEARCH_PRODUCT_FAILURE,
            payload: error
        })
    }
}

export function* createProduct({ payload }) {
    try {
        var res = yield postProduct(payload)
        yield put({
            type: CREATE_PRODUCT_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: CREATE_PRODUCT_FAILURE,
            payload: error
        })
    }
}

export function* removeProduct({ payload }) {
    try {
        var res = yield deleteProduct(payload)
        yield put({
            type: DELETE_PRODUCT_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: DELETE_PRODUCT_FAILURE,
            payload: error
        })
    }
}

export function* updateProduct({ payload }) {
    try {
        var res = yield putProduct(payload)
        yield put({
            type: UPDATE_PRODUCT_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: UPDATE_PRODUCT_FAILURE,
            payload: error
        })
    }
}