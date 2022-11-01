import { put } from 'redux-saga/effects'
import { getProducts, postProduct } from '../../../api/product'
import { CREATE_PRODUCT_FAILURE, CREATE_PRODUCT_SUCCESS, SEARCH_PRODUCT_FAILURE, SEARCH_PRODUCT_SUCCESS } from './productActionTypes'

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

