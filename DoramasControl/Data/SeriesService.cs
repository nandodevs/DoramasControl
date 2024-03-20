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
            return await _httpClient.GetFromJsonAsync<SeriesModel[]>(requestUri: "http://127.0.0.1:5000/api/doramas/legendado");
        }
    }
}
