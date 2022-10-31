import { put } from 'redux-saga/effects'
import { getProducts } from '../../../api/product'
import { SEARCH_PRODUCT_FAILURE, SEARCH_PRODUCT_SUCCESS } from './productActionTypes'

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

