import { SIGNIN_FAILURE, SIGNIN_REQUEST } from "./userActionTypes";

const init = {
    user: null,
    loading: true,
    accessToken: null,
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
        case SIGNIN_FAILURE:
            return {
                ...state,
                loading: false,
                user: null,
                error: {
                    action: type,
                    message: payload
                }
            };
        default:
            return state;
    }
}