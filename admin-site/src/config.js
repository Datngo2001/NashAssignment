export const { NODE_ENV, APP_API_URL } = process.env;

let apiurl;
if (NODE_ENV === 'development') {
  apiurl = 'https://localhost:5003/api';
} else {
  if (APP_API_URL) {
    apiurl = APP_API_URL;
  } else {
    apiurl = 'https://group01-softwaretesting-api.azurewebsites.net/api';
  }
}
export const API_URL = apiurl;
