using ConsumerApi.Dto;
using System.Text.Json;

namespace ConsumerApi.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthService> _logger;
        private readonly IConfiguration _config;

        public AuthService(HttpClient httpClient, ILogger<AuthService> logger, IConfiguration config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _config = config;
        }

        public async Task<UserDto> LoginAsync(string username, string password)
        {
            var loginModel = new
            {
                Username = username,
                Password = password
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(_config["UrlAuth"], loginModel);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserializar la respuesta JSON en un LoginResponseDto
                var loginResponse = JsonSerializer.Deserialize<UserDto>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return loginResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while sending the login request.");
                throw;
            }
        }
    }
}
