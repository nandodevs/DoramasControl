using DoramasControl.Models;

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
            //Retorno da API no Vercel
            return await _httpClient.GetFromJsonAsync<DramaViewModel[]>(requestUri: "https://mdl-api-wine.vercel.app/api/doramas-stars");
        }
    }
}
