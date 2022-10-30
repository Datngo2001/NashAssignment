import { SIGNIN_REQUEST, SIGNIN_SUCCESS } from "./userActionTypes";

const init = {
    user: null,
    loading: true,
    error: {
        action: "",
        message: null
    }
}

export default function userReducer(state = init, { type, payload }) {
    switch (type) {
        case SIGNIN_REQUEST:
            return {
                ...state,
                loading: true,
                user: null,
                error: {
                    action: "",
                    message: null
                }
            };
        case SIGNIN_SUCCESS:
            return {
                ...state,
                loading: false,
                user: payload,
            };
        default:
            return state;
    }
}