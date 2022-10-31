export const { NODE_ENV } = process.env;

let apiurl;
if (NODE_ENV === 'development') {
  apiurl = 'http://localhost:3001/';
} else {
  apiurl = 'https://e-working-api.herokuapp.com/';
}
export const API_URL = apiurl;
