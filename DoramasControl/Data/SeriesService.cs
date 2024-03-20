using DoramasControl.Models;

namespace DoramasControl.Data
{
    
    public class SeriesService
    {
        private readonly HttpClient _httpClient;

        public SeriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SeriesModel[]> GetSeries()
        {
            //Retorno da API no Vercel
            return await _httpClient.GetFromJsonAsync<SeriesModel[]>(requestUri: "https://mdl-api-wine.vercel.app/api/series-legendado");
        }
    }
}
