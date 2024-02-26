using Microsoft.AspNetCore.Mvc;
using DoramasControl.Models;
using System;
using System.Linq;

namespace DoramasControl.Controllers
{
    public class DoramasController : Controller
    {
        // Simula um banco de dados ou contexto real
        private static readonly List<DoramasModel> _doramasList = new List<DoramasModel>();

        // GET: Doramas
        public IActionResult Index()
        {
            return View(_doramasList);
        }

        // GET: Doramas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoramasModel dorama = _doramasList.FirstOrDefault(m => m.Id == id);

            if (dorama == null)
            {
                return NotFound();
            }

            return View(dorama);
        }

        // GET: Doramas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doramas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nacionalidade,Nome,Status,QtdEpisodios,DataInicio,DataFim")] DoramasModel dorama)
        {
            if (ModelState.IsValid)
            {
                dorama.Id = _doramasList.Count + 1;
                _doramasList.Add(dorama);
                return RedirectToAction(nameof(Index));
            }

            return View(dorama);
        }

        // GET: Doramas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoramasModel dorama = _doramasList.FirstOrDefault(m => m.Id == id);

            if (dorama == null)
            {
                return NotFound();
            }

            return View(dorama);
        }

        // POST: Doramas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nacionalidade,Nome,Status,QtdEpisodios,DataInicio,DataFim")] DoramasModel dorama)
        {
            if (id != dorama.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DoramasModel existingDorama = _doramasList.FirstOrDefault(m => m.Id == id);
                    if (existingDorama != null)
                    {
                        existingDorama.Nacionalidade = dorama.Nacionalidade;
                        existingDorama.Nome = dorama.Nome;
                        existingDorama.Status = dorama.Status;
                        existingDorama.QtdEpisodios = dorama.QtdEpisodios;
                        existingDorama.DataInicio = dorama.DataInicio;
                        existingDorama.DataFim = dorama.DataFim;
                    }
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dorama);
        }

        // GET: Doramas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DoramasModel dorama = _doramasList.FirstOrDefault(m => m.Id == id);

            if (dorama == null)
            {
                return NotFound();
            }

            return View(dorama);
        }

        // POST: Doramas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            DoramasModel dorama = _doramasList.FirstOrDefault(m => m.Id == id);
            if (dorama != null)
            {
                _doramasList.Remove(dorama);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
