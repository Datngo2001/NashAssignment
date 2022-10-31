import api from "./";

export function getProducts(query, page, limit) {
    return api.get(`Product/admin/search?query=${query}&page=${page}&limit=${limit}`);
}