using DoramasControl.Data;
using Microsoft.AspNetCore.Mvc;

namespace DoramasControl.Controllers
{
    public class DramaController(DramaService dramaService) : Controller
    {
        private readonly DramaService _dramaService = dramaService;

        public async Task<IActionResult> Index()
        {
            var dramas = await _dramaService.GetTopDramas();
            return View(dramas);
        }
    }

}
