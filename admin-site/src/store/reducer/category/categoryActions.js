import { put } from 'redux-saga/effects'
import { getCategorys, postCategory } from '../../../api/product'
import { CREATE_CATEGORY_FAILURE, CREATE_CATEGORY_SUCCESS, SEARCH_CATEGORY_FAILURE, SEARCH_CATEGORY_SUCCESS } from './productActionTypes'

export function* searchCategory({ payload }) {
    try {
        var res = yield getCategorys(payload.query, payload.page, payload.limit)
        yield put({
            type: SEARCH_CATEGORY_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: SEARCH_CATEGORY_FAILURE,
            payload: error
        })
    }
}

export function* createCategory({ payload }) {
    try {
        var res = yield postCategory(payload)
        yield put({
            type: CREATE_CATEGORY_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: CREATE_CATEGORY_FAILURE,
            payload: error
        })
    }
}

