using DoramasControl.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoramasControl.Controllers
{
    public class SeriesController(SeriesService seriesService) : Controller
    {
        private readonly SeriesService _seriesService = seriesService;

        public async Task<IActionResult> Index()
        {
            var series = await _seriesService.GetAllSeries();
            return View(series); // Passe o objeto SeriesViewModel para a visualização
        }
    }
}
