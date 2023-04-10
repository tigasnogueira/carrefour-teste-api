using Carrefour.Mvc.Extensions;
using Carrefour.Mvc.Models;
using Microsoft.Extensions.Options;

namespace Carrefour.Mvc.Services
{
    public class AuthenticationService : Service, IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient,
                                   IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.AuthenticationUrl);

            _httpClient = httpClient;
        }

        public async Task<UserloginResponse> Login(UserLogin userLogin)
        {
            var loginContent = GetContent(userLogin);

            var response = await _httpClient.PostAsync("/api/identidade/autenticar", loginContent);

            if (!HandleErrorsResponse(response))
            {
                return new UserloginResponse
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<UserloginResponse>(response);
        }

        public async Task<UserloginResponse> Register(UserRegister userRegister)
        {
            var registroContent = GetContent(userRegister);

            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

            if (!HandleErrorsResponse(response))
            {
                return new UserloginResponse
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            }

            return await DeserializeObjectResponse<UserloginResponse>(response);
        }
    }
}
