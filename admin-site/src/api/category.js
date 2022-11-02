import api from "./";

export function getCategories(query, page, limit) {
    return api.post("Category/admin/search", {
        query, page, limit
    });
}

export function postCategory(data) {
    return api.post("Category/create", data);
}

export function deleteCategory(id) {
    return api.delete(`Category/delete/${id}`);
}

export function putCategory(data) {
    return api.put("Category/update", data);
}