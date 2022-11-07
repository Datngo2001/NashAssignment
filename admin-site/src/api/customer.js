import api from "./";

export function getCustomers(query, page, limit) {
    return api.post("User/search", {
        query, page, limit
    });
}

export function getCustomerClaims(id) {
    return api.get(`User/claims/${id}`);
}