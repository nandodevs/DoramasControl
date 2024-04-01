using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DoramasControl.Models;
using Microsoft.Extensions.Caching.Memory;

namespace DoramasControl.Data
{
    public class DramaService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;

        public DramaService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<DramaViewModel[]> GetTopDramas()
        {
            // Verifica se os dados já estão em cache
            if (!_cache.TryGetValue("topDramas", out DramaViewModel[] topDramas))
            {
                // Se não estiver em cache, faz a consulta à API
                var response = await _httpClient.GetAsync("https://mdl-flask-api.onrender.com/api/doramas-stars");
                response.EnsureSuccessStatusCode();
                topDramas = await response.Content.ReadFromJsonAsync<DramaViewModel[]>();

                // Armazena os dados em cache por 10 minutos
                _cache.Set("topDramas", topDramas, TimeSpan.FromMinutes(10));
            }

            return topDramas;
        }
    }
}
