using DoramasControl.Models;
using Microsoft.AspNetCore.Http;

namespace DoramasControl.Data
{
    public class DramaService
    {
        private readonly HttpClient _httpClient;

        public DramaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DramaViewModel[]> GetTopDramas()
        {
            return await _httpClient.GetFromJsonAsync<DramaViewModel[]>(requestUri: "https://mdl-api-wine.vercel.app/api/top-dramas");
        }
    }
}
