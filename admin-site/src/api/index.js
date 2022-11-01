import axios from "axios";
import { API_URL } from "../config";
import store from "../store";

function getToken() {
    const token = store.getState().user.user.access_token;
    return token ? `Bearer ${token}` : null;
}

const api = axios.create({
    baseURL: API_URL,
});

api.interceptors.request.use(
    function (config) {
        if (!config.headers.Authorization) {
            config.headers.Authorization = getToken();
        }
        return config;
    },
    function (error) {
        return Promise.reject(error);
    }
);
api.interceptors.response.use(
    function (config) {
        return config;
    },
    function (error) {
        return Promise.reject(error.response.data);
    }
);
export default api;
