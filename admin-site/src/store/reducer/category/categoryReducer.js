import { CREATE_CATEGORY_FAILURE, CREATE_CATEGORY_REQUEST, CREATE_CATEGORY_SUCCESS, SEARCH_CATEGORY_FAILURE, SEARCH_CATEGORY_REQUEST, SEARCH_CATEGORY_SUCCESS } from "./CATEGORYActionTypes";

const init = {
    query: "",
    page: 1,
    limit: 5,
    count: 0,
    totalPage: 0,
    categories: [],
    loading: true,
    error: {
        action: "",
        message: null
    }
}

export default function categoryReducer(state = init, { type, payload }) {
    switch (type) {
        case CREATE_CATEGORY_REQUEST:
        case SEARCH_CATEGORY_REQUEST:
            return {
                ...state,
                loading: true,
                error: {
                    action: "",
                    message: null
                }
            };
        case CREATE_CATEGORY_FAILURE:
        case SEARCH_CATEGORY_FAILURE:
            return {
                ...state,
                loading: false,
                error: {
                    action: type,
                    message: payload.message
                }
            };
        case SEARCH_CATEGORY_SUCCESS:
            return {
                ...state,
                ...payload,
                categories: payload.items,
                loading: false,
            };
        case CREATE_CATEGORY_SUCCESS:
            return {
                ...state,
                categories: [payload, ...state.categories],
                loading: false,
            };
        default:
            return state;
    }
}