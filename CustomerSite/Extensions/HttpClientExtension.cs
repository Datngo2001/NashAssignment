using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CustomerSite.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<ResponseType?> GetApiAsync<ResponseType>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var result = await getResult<ResponseType>(response);
            return result;
        }
        public static async Task<double> GetApiNumberAsync(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            var result = Convert.ToDouble(contents);
            return result;
        }

        public static async Task<ResponseType?> PostApiAsync<ParamType, ResponseType>(this HttpClient httpClient, string url, ParamType param)
        {
            var jsonString = JsonConvert.SerializeObject(param);
            var response = await httpClient.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            var result = await getResult<ResponseType>(response);
            return result;
        }

        public static async Task<ResponseType?> PutApiAsync<ParamType, ResponseType>(this HttpClient httpClient, string url, ParamType param)
        {
            var jsonString = JsonConvert.SerializeObject(param);
            var response = await httpClient.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            var result = await getResult<ResponseType>(response);
            return result;
        }

        public static async Task<ResponseType?> DeleteApiAsync<ResponseType>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.DeleteAsync(url);
            var result = await getResult<ResponseType>(response);
            return result;
        }

        private static async Task<T?> getResult<T>(HttpResponseMessage response)
        {
            var contents = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(contents);
            return result;
        }

        #region with accessToken

        public static async Task<ResponseType?> GetApiAsync<ResponseType>(this HttpClient httpClient, string url, string accessToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); ;
            var response = await httpClient.GetAsync(url);
            var result = await getResult<ResponseType>(response);
            return result;
        }
        public static async Task<double> GetApiNumberAsync(this HttpClient httpClient, string url, string accessToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); ;
            var response = await httpClient.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            var result = Convert.ToDouble(contents);
            return result;
        }

        public static async Task<ResponseType?> PostApiAsync<ParamType, ResponseType>(this HttpClient httpClient, string url, ParamType param, string accessToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); ;
            var jsonString = JsonConvert.SerializeObject(param);
            var response = await httpClient.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            var result = await getResult<ResponseType>(response);
            return result;
        }

        public static async Task<ResponseType?> PutApiAsync<ParamType, ResponseType>(this HttpClient httpClient, string url, ParamType param, string accessToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); ;
            var jsonString = JsonConvert.SerializeObject(param);
            var response = await httpClient.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            var result = await getResult<ResponseType>(response);
            return result;
        }

        public static async Task<ResponseType?> DeleteApiAsync<ResponseType>(this HttpClient httpClient, string url, string accessToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken); ;
            var response = await httpClient.DeleteAsync(url);
            var result = await getResult<ResponseType>(response);
            return result;
        }

        #endregion
    }
}