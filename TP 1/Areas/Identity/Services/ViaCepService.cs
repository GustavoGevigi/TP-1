using System.Net.Http;
using System.Threading.Tasks;

namespace TP_1.Areas.Identity.Services
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EnderecoDto> ConsultarCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();
            var enderecoDto = JsonSerializer.Deserialize<EnderecoDto>(contentString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return enderecoDto;
        }
    }
}
