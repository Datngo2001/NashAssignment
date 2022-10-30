import { call, put } from 'redux-saga/effects'
import { SIGNIN_FAILURE } from './userActionTypes'
import UserManager from "../../../oidc/userManager"

export function* signin() {
    UserManager.signinRedirect();
}

export function* signout() {
    UserManager.signoutRedirect();
}

export function* checkUserStatus() {
    try {
        debugger
        var user = yield call(UserManager.getUser);
        if (user) {
            console.log(user)
            yield put({
                type: SIGNIN_FAILURE,
                payload: user
            })
        } else {
            yield put({
                type: SIGNIN_FAILURE,
                payload: user
            })
        }
    } catch (error) {
        console.log(error)
    }
}
