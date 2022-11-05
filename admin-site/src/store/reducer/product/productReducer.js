import { removeElementById, updateElementById } from "../../../util/array";
import { CREATE_PRODUCT_FAILURE, CREATE_PRODUCT_REQUEST, CREATE_PRODUCT_SUCCESS, DELETE_PRODUCT_FAILURE, DELETE_PRODUCT_REQUEST, DELETE_PRODUCT_SUCCESS, SEARCH_PRODUCT_FAILURE, SEARCH_PRODUCT_REQUEST, SEARCH_PRODUCT_SUCCESS, UPDATE_PRODUCT_FAILURE, UPDATE_PRODUCT_REQUEST, UPDATE_PRODUCT_SUCCESS } from "./productActionTypes";

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
        case UPDATE_PRODUCT_REQUEST:
        case DELETE_PRODUCT_REQUEST:
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
        case DELETE_PRODUCT_FAILURE:
        case UPDATE_PRODUCT_FAILURE:
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
        case DELETE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: removeElementById(state.products, payload),
                loading: false,
            };
        case UPDATE_PRODUCT_SUCCESS:
            return {
                ...state,
                products: updateElementById(state.products, payload),
                loading: false,
            };
        default:
            return state;
    }
}
