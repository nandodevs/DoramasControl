using DoramasControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DoramasControl.Data
{
    public class SeriesService
    {
        private readonly HttpClient _httpClient;

        public SeriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Considerando que você já tem um método para obter todos os dados
        public async Task<IEnumerable<SeriesModel>> GetSeries(int page, int pageSize)
        {
            // Exemplo de lógica de paginação:
            var allSeries = await GetAllSeries();
            var paginatedSeries = allSeries.Skip((page - 1) * pageSize).Take(pageSize);
            return paginatedSeries;
        }

        internal int GetTotalPages(int pageSize)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<SeriesModel>> GetAllSeries()
        {
            // Implemente o código para obter todos os dados do seu armazenamento de dados
            // Por exemplo, banco de dados, chamada de API, etc.
            // Retorna todos os dados
            return await _httpClient.GetFromJsonAsync<SeriesModel[]>(requestUri: "http://127.0.0.1:5000/api/doramas/legendado");
        }
    }
}
