using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace CoreVC.Api.Rest
{
    public class RestClient
    {
        public async Task<T> Request<T>(Uri url)
            where T : class
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "CoreVC");

            var stream = await httpClient.GetStreamAsync(url);
            var serializer = new DataContractJsonSerializer(typeof(T));

            return serializer.ReadObject(stream) as T;
        }
    }
}
