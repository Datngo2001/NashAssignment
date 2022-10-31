import api from "./";

export function getProducts(query, page, limit) {
    return api.post("Product/admin/search", {
        query, page, limit
    });
}