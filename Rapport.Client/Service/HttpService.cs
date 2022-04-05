
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rapport.Client.Service
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;

        public HttpService(IHttpClientFactory _httpClientFactory)
        {

            _client = _httpClientFactory.CreateClient("ReportUri");
        }


        public async Task<HttpResponseWrapper<T>> Get<T>(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseDeserialized = await Deserialize<T>(response);

                    return new HttpResponseWrapper<T>(true, responseDeserialized, response);
                }
                else
                {
                    return new HttpResponseWrapper<T>(false, default, response);
                }

            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("kunne ikke få fat i httpservice", ex);
            }

        }


        public async Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            try
            {
                string dataJson = JsonSerializer.Serialize(data, IgnoreNullSerializerOption());

                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseDeserialized = await Deserialize<TResponse>(response);

                    return new HttpResponseWrapper<TResponse>(true, responseDeserialized, response);
                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(false, default, response);

                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("kunne ikke få fat i httpservice", ex);
            }

        }

        public async Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data)
        {
            try
            {
                string dataJson = JsonSerializer.Serialize(data, IgnoreNullSerializerOption());

                var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = await _client.PutAsync(url, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    var responseDeserialized = await Deserialize<TResponse>(response);
                    return new HttpResponseWrapper<TResponse>(true, responseDeserialized, response);

                }
                else
                {
                    return new HttpResponseWrapper<TResponse>(false, default, response);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("kunne ikke få fat i httpservice", ex);
            }
        }

        public async Task<HttpResponseWrapper<object>> Delete(string url)
        {
            try
            {
                var response = await _client.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseWrapper<object>(true, response.IsSuccessStatusCode, response);

                }
                else
                {
                    return new HttpResponseWrapper<object>(false, default, response);
                }

            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException("kunne ikke få fat i httpservice", ex);
            }


        }


        // Deserialize HttpResponse from json to C# objects 
        private static async Task<T> Deserialize<T>(HttpResponseMessage httpResponse)
        {
            var serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true, ReferenceHandler = ReferenceHandler.Preserve };
            string response = await httpResponse.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(response, serializerOptions);
        }

        private static JsonSerializerOptions IgnoreNullSerializerOption()
        {
            var serializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true
            };

            return serializerOptions;
        }
    }
}
