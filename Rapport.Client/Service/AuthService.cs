using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Rapport.Shared.Dto_er.User;

namespace Rapport.Client.Service
{
    public class AuthService : IAuthService
    {

        public HttpClient _httpClient { get; }
        public AppSettings _appSettings { get; }

        public AuthService(IHttpService httpService, HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            
            httpClient.BaseAddress = new Uri("https://localhost:5443");

            _httpClient = httpClient;
        }

        public async Task<LoginDto> LoginAsync(LoginDto user)
        {
            try
            {
                user.Password = Utility.Encrypt(user.Password);
                string serializedUser = JsonConvert.SerializeObject(user);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "authentication/login");
                requestMessage.Content = new StringContent(serializedUser);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<LoginDto>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }

        public async Task<RegisterDto> RegisterUserAsync(RegisterDto user)
        {
            try
            {
                user.Password = Utility.Encrypt(user.Password);
                string serializedUser = JsonConvert.SerializeObject(user);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Auth/RegisterUser");
                requestMessage.Content = new StringContent(serializedUser);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<RegisterDto>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    
        }

        public async Task<LoginDto> RefreshTokenAsync(RefreashRequest refreshRequest)
        {
            try
            {
                string serializedUser = JsonConvert.SerializeObject(refreshRequest);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Users/RefreshToken");
                requestMessage.Content = new StringContent(serializedUser);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<LoginDto>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

        public async Task<LoginDto> GetUserByAccessTokenAsync(string accessToken)
        {
            try
            {
                string serializedRefreshRequest = JsonConvert.SerializeObject(accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Auth/GetUserByAccessToken");
                requestMessage.Content = new StringContent(serializedRefreshRequest);

                requestMessage.Content.Headers.ContentType
                    = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await _httpClient.SendAsync(requestMessage);

                var responseStatusCode = response.StatusCode;
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedUser = JsonConvert.DeserializeObject<LoginDto>(responseBody);

                return await Task.FromResult(returnedUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
      
        }
    }
}
