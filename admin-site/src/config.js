export const { NODE_ENV } = process.env;

let apiurl;
if (NODE_ENV === 'development') {
  apiurl = 'https://localhost:5003/api';
} else {
  apiurl = '';
}
export const API_URL = apiurl;
