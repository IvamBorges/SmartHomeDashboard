using System.Text.Json;
using SmartHomeDashboard.Models;

namespace SmartHomeDashboard.Services
{
    public class ClimaService
    {
        private readonly HttpClient _httpClient;

        public ClimaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Clima?> ObterClimaAsync()
        {
            try
            {
                var url =
                    "https://api.open-meteo.com/v1/forecast" +
                    "?latitude=-23.55" +
                    "&longitude=-46.63" +
                    "&current=temperature_2m,relative_humidity_2m" +
                    "&timezone=America%2FSao_Paulo";

                var json = await _httpClient.GetStringAsync(url);

                using var documento = JsonDocument.Parse(json);

                var atual = documento.RootElement
                    .GetProperty("current");

                var temperatura = atual
                    .GetProperty("temperature_2m")
                    .GetDouble();

                var umidade = atual
                    .GetProperty("relative_humidity_2m")
                    .GetInt32();

                return new Clima
                {
                    Temperatura = temperatura,
                    Umidade = umidade
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao consultar clima: {ex.Message}");

                return null;
            }
        }
    }
}