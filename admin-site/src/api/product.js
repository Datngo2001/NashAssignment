import api from "./";

export function getProducts(query, page, limit) {
    return api.post("Product/admin/search", {
        query, page, limit
    });
}

export function postProduct(data) {
    return api.post("Product/create", data);
}

export function putProduct(data) {
    return api.put("Product/update", data);
}

export function deleteProduct(id) {
    return api.delete(`Product/delete/${id}`);
}
