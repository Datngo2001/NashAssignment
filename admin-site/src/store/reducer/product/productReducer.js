import { SEARCH_PRODUCT_FAILURE, SEARCH_PRODUCT_REQUEST, SEARCH_PRODUCT_SUCCESS } from "./productActionTypes";

const init = {
    query: "",
    page: 1,
    limit: 5,
    count: 0,
    totalPage: 0,
    products: [],
    loading: true,
    error: {
        action: "",
        message: null
    }
}

export default function productReducer(state = init, { type, payload }) {
    switch (type) {
        case SEARCH_PRODUCT_REQUEST:
            return {
                ...state,
                loading: true,
                error: {
                    action: "",
                    message: null
                }
            };
        case SEARCH_PRODUCT_SUCCESS:
            return {
                ...state,
                ...payload,
                products: payload.items,
                loading: false,
            };
        case SEARCH_PRODUCT_FAILURE:
            return {
                ...state,
                loading: false,
                error: {
                    action: type,
                    message: payload.message
                }
            };
        default:
            return state;
    }
}