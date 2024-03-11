using System.Diagnostics;
using DoramasControl.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoramasControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Kdramas()
        {
            // Simulação de dados do carrossel
            var carouselItems = new List<CarouselItem>
        {
            new CarouselItem { Imagem = "url_imagem_1", Titulo = "Título 1", Classificacao = 9.5F },
            new CarouselItem { Imagem = "url_imagem_2", Titulo = "Título 2", Classificacao = 8.7F },
            // Adicione mais itens conforme necessário
        };

            return View(carouselItems);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
