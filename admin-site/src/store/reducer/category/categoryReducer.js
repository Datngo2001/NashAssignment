import { CREATE_CATEGORY_FAILURE, CREATE_CATEGORY_REQUEST, CREATE_CATEGORY_SUCCESS, DELETE_CATEGORY_FAILURE, DELETE_CATEGORY_REQUEST, DELETE_CATEGORY_SUCCESS, SEARCH_CATEGORY_FAILURE, SEARCH_CATEGORY_REQUEST, SEARCH_CATEGORY_SUCCESS, UPDATE_CATEGORY_FAILURE, UPDATE_CATEGORY_REQUEST, UPDATE_CATEGORY_SUCCESS } from "./categoryActionTypes";

const init = {
    query: "",
    page: 1,
    limit: 5,
    count: 0,
    totalPage: 1,
    categories: [],
    loading: true,
    error: {
        action: "",
        message: null
    }
}

export default function categoryReducer(state = init, { type, payload }) {
    switch (type) {
        case UPDATE_CATEGORY_REQUEST:
        case DELETE_CATEGORY_REQUEST:
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
        case UPDATE_CATEGORY_FAILURE:
        case DELETE_CATEGORY_FAILURE:
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
        case DELETE_CATEGORY_SUCCESS:
            return {
                ...state,
                categories: removeCategoryFromStore(state.categories, payload),
                loading: false,
            };

        case UPDATE_CATEGORY_SUCCESS:
            return {
                ...state,
                categories: updateCategoryFromStore(state.categories, payload),
                loading: false,
            };
        default:
            return state;
    }
}

function removeCategoryFromStore(categories, toDelete) {
    let index = categories.findIndex(c => c.id === toDelete.id)
    categories.splice(index, 1)
    return categories
}

function updateCategoryFromStore(categories, toUpdate) {
    let index = categories.findIndex(c => c.id === toUpdate.id)
    categories[index] = toUpdate;
    return categories
}