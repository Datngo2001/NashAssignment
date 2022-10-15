using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CustomerSite.Extensions
{
    public static class HttpClientExtension
    {
        public static async Task<ResponseType?> PostApiAsync<ParamType, ResponseType>(this HttpClient httpClient, string url, ParamType param)
        {
            var jsonString = JsonConvert.SerializeObject(param);
            var response = await httpClient.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
            var contents = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseType>(contents);
            return result;
        }
    }
}