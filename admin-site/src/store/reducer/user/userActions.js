import { put } from 'redux-saga/effects'
import { CHECK_USER_STATUS, SIGNIN_SUCCESS } from './userActionTypes'
import UserManager from "../../../oidc/userManager"

export function signin() {
    try {
        UserManager.signinRedirect();
    } catch (error) {
        console.log(error)
    }
}

export function signout() {
    try {
        UserManager.signoutRedirect();
    } catch (error) {
        console.log(error)
    }
}

export function* signinCallback() {
    try {
        yield UserManager.signinRedirectCallback()
        yield put({
            type: CHECK_USER_STATUS,
        })
    } catch (error) {
        console.log(error)
    }
}

export function* checkUserStatus() {
    try {
        var user = yield UserManager.getUser()
        yield put({
            type: SIGNIN_SUCCESS,
            payload: user
        })
    } catch (error) {
        console.log(error)
    }
}
