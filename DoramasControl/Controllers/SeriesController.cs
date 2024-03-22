using DoramasControl.Data;
using DoramasControl.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DoramasControl.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesService _seriesService;

        public SeriesController(SeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 20;
            IEnumerable<Models.SeriesModel> series = await _seriesService.GetSeries(page, pageSize);

            // Aqui, crie um objeto SeriesViewModel e preencha com os dados e informações de página
            var viewModel = new SeriesViewModel
            {
                Series = (List<Models.SeriesModel>)series,
                CurrentPage = page, // Preencha com o número da página atual
                TotalPages = _seriesService.GetTotalPages(pageSize) // Obtenha o número total de páginas
            };

            return View(viewModel); // Passe o objeto SeriesViewModel para a visualização
        }
    }
}
