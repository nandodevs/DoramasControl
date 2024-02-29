using Microsoft.AspNetCore.Mvc;
using DoramasControl.Models;
using DoramasControl.Data;

namespace DoramasControl.Controllers
{
    public class DoramasController(ApplicationDbContext db) : Controller
    {
        readonly private ApplicationDbContext _db = db;

        public IActionResult Index()
        {
            IEnumerable<DoramasModel> doramas = _db.Doramas;

            return View(doramas);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound("O ID não foi fornecido ou é inválido.");
                }

                DoramasModel doramas = _db.Doramas.FirstOrDefault(x => x.Id == Convert.ToInt32(id));


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


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound("O ID não foi fornecido ou é inválido.");
                }

                DoramasModel doramas = _db.Doramas.FirstOrDefault(x => x.Id == Convert.ToInt32(id));


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


        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(DoramasModel doramas)
        {
            if (ModelState.IsValid)
            {
                //Entra no BD -> Tabela Doramas -> Insere os dados
                _db.Doramas.Add(doramas);
                _db.SaveChanges(); //Salva os dados
                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index"); //Retorno para a tela Index de Empréstimos
            }
            return View(doramas);
        }

        [HttpPost]
        public IActionResult Editar(DoramasModel doramas)
        {
            if (ModelState.IsValid)
            {
                _db.Doramas.Update(doramas);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Erro ao editar o empréstimo!";
            return View(doramas);
        }

        [HttpPost]
        public IActionResult Excluir(DoramasModel doramas)
        {
            if (doramas == null)
            {
                return NotFound();
            }

            _db.Doramas.Remove(doramas);
            _db.SaveChanges();

            TempData["MensagemSucesso"] = "Exclusão realizada com sucesso!";
            return RedirectToAction("Index");
        }
    }
}

