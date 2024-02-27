using Microsoft.AspNetCore.Mvc;
using DoramasControl.Models;
using DoramasControl.Data;

namespace DoramasControl.Controllers
{
    public class DoramasController(ApplicationDbContext db) : Controller
    {
        // Simula um banco de dados ou contexto real
        readonly private ApplicationDbContext _doramasList = db;

        // GET: Doramas
        public IActionResult Index()
        {
            IEnumerable<DoramasModel> doramas = _doramasList.Doramas;
            return View(doramas);
        }

        // GET: Doramas/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doramas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nacionalidade,Nome,Status,QtdEpisodios,DataInicio,DataFim")] DoramasModel doramas)
        {
            if (ModelState.IsValid)
            {
                _doramasList.Doramas.Add(doramas);
                _doramasList.SaveChanges();
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            return View(doramas);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound("O ID não foi fornecido ou é inválido.");
                }

                DoramasModel doramas = _doramasList.Doramas.FirstOrDefault(x => x.Id == id);

                if (doramas == null)
                {
                    return NotFound("Nenhum Dorama encontrado com o ID fornecido.");
                }

                return View(doramas);
            }
            catch (Exception ex)
            {
                // Registre ou manipule a exceção conforme necessário
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DoramasModel dorama)
        {
            if (ModelState.IsValid)
            {
                _doramasList.Doramas.Update(dorama);
                _doramasList.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");

            }
            TempData["MensagemErro"] = "Erro ao editar o empréstimo!";
            return View(dorama);
        }

        // POST Deletado
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(DoramasModel dorama)
        {
            if (dorama == null)
            {
                return NotFound();
            }

            _doramasList.Doramas.Remove(dorama);
            _doramasList.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpGet] //Obter Excluídos por ID
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound("O ID não foi fornecido ou é inválido.");
                }

                DoramasModel doramas = _doramasList.Doramas.FirstOrDefault(x => x.Id == id);

                if (doramas == null)
                {
                    return NotFound("Nenhum empréstimo encontrado com o ID fornecido.");
                }

                return View(doramas);
            }
            catch (Exception ex)
            {
                // Registre ou manipule a exceção conforme necessário
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
