using Rapport.Client.Helpers;

namespace Rapport.Client.Interfaces
{
    public interface IHttpService
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);
        Task<HttpResponseWrapper<object>> Delete(string url);

        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data);
    }
}
