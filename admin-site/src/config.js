export const { NODE_ENV } = process.env;

let apiurl;
if (NODE_ENV === 'development') {
  apiurl = 'https://localhost:6001/api';
} else {
  apiurl = '';
}
export const API_URL = apiurl;
