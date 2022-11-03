import { CREATE_PRODUCT_FAILURE, CREATE_PRODUCT_REQUEST, CREATE_PRODUCT_SUCCESS, SEARCH_PRODUCT_FAILURE, SEARCH_PRODUCT_REQUEST, SEARCH_PRODUCT_SUCCESS } from "./productActionTypes";

const init = {
    query: "",
    page: 1,
    limit: 5,
    count: 0,
    totalPage: 1,
    products: [],
    loading: true,
    error: {
        action: "",
        message: null
    }
}

export default function productReducer(state = init, { type, payload }) {
    switch (type) {
        case CREATE_PRODUCT_REQUEST:
        case SEARCH_PRODUCT_REQUEST:
            return {
                ...state,
                loading: true,
                error: {
                    action: "",
                    message: null
                }
            };
        case CREATE_PRODUCT_FAILURE:
        case SEARCH_PRODUCT_FAILURE:
            return {
                ...state,
                loading: false,
                error: {
                    action: type,
                    message: payload.message
                }
            };
        case SEARCH_PRODUCT_SUCCESS:
            return {
                ...state,
                ...payload,
                products: payload.items,
                loading: false,
            };
        case CREATE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: [payload, ...state.products],
                loading: false,
            };
        default:
            return state;
    }
}