import { SEARCH_CUSTOMER_REQUEST, SEARCH_CUSTOMER_SUCCESS, SEARCH_CUSTOMER_FAILURE } from "./customerActionTypes";

const init = {
    query: "",
    page: 1,
    limit: 5,
    count: 0,
    totalPage: 1,
    customers: [],
    loading: true,
    error: {
        action: "",
        message: null
    }
}

export default function customerReducer(state = init, { type, payload }) {
    switch (type) {
        case SEARCH_CUSTOMER_REQUEST:
            return {
                ...state,
                loading: true,
                error: {
                    action: "",
                    message: null
                }
            };
        case SEARCH_CUSTOMER_FAILURE:
            return {
                ...state,
                loading: false,
                error: {
                    action: type,
                    message: payload.message
                }
            };
        case SEARCH_CUSTOMER_SUCCESS:
            return {
                ...state,
                ...payload,
                customers: payload.items,
                loading: false,
            };
        default:
            return state;
    }
}