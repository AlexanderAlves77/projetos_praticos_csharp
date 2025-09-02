using BrasilApiConnector.Dtos;
using BrasilApiConnector.Interfaces;
using System.Text.Json;


namespace BrasilApiConnector.Infrastructure.Api
{
    public class BrasilApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public BrasilApiClient(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://brasilapi.com.br/");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<BrasilApiCepDto?> GetCepAsync(string cep)
        {
            try
            {
                using var resp = await _httpClient.GetAsync($"/api/cep/v2/{cep}");
                if (!resp.IsSuccessStatusCode) return null;

                var json = await resp.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<BrasilApiCepDto>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return dto;
            }
            catch (TaskCanceledException)
            {
                // Timeout
                return null;
            }
            catch (HttpRequestException)
            {
                // Erro de rede
                return null;
            }
            catch (Exception)
            {
                // Qualquer outro erro inesperado
                return null;
            }
        }
    }    
}
