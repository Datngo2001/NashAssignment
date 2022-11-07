import { put } from 'redux-saga/effects'
import { getCustomers } from '../../../api/customer'
import { SEARCH_CUSTOMER_FAILURE, SEARCH_CUSTOMER_SUCCESS } from './customerActionTypes'

export function* searchCustomer({ payload }) {
    try {
        var res = yield getCustomers(payload.query, payload.page, payload.limit)
        yield put({
            type: SEARCH_CUSTOMER_SUCCESS,
            payload: res.data
        })
    } catch (error) {
        yield put({
            type: SEARCH_CUSTOMER_FAILURE,
            payload: error
        })
    }
}
