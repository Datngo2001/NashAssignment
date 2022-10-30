import { call, put } from 'redux-saga/effects'
import { SIGNIN_FAILURE, SIGNOUT_FAILURE, } from './userActionTypes'
import { signoutFirebase, signInToFirebaseWithEmail } from '../../../firebase/auth'

export function* signin({ payload }) {
    try {
        yield call(signInToFirebaseWithEmail, payload.email, payload.password)
    } catch (error) {
        yield put({
            type: SIGNIN_FAILURE,
            payload: error
        })
    }
}

export function* signout({ payload }) {
    try {
        yield call(signoutFirebase)
        payload.success()
    } catch (error) {
        yield put({
            type: SIGNOUT_FAILURE,
            payload: error
        })
    }
}
