import api from "./";

export function getCategories(query, page, limit) {
    return api.post("Category/admin/search", {
        query, page, limit
    });
}

export function postCategory(data) {
    return api.post("Category/create", data);
}