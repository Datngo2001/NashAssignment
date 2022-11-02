import { put } from 'redux-saga/effects'
import { deleteCategory, getCategories, postCategory } from '../../../api/category'
import { CREATE_CATEGORY_FAILURE, CREATE_CATEGORY_SUCCESS, DELETE_CATEGORY_FAILURE, DELETE_CATEGORY_SUCCESS, SEARCH_CATEGORY_FAILURE, SEARCH_CATEGORY_SUCCESS } from './categoryActionTypes'

export function* searchCategory({ payload }) {
    try {
        var res = yield getCategories(payload.query, payload.page, payload.limit)
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

export function* removeCategory({ payload }) {
    try {
        var res = yield deleteCategory(payload)
        yield put({
            type: DELETE_CATEGORY_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: DELETE_CATEGORY_FAILURE,
            payload: error
        })
    }
}