using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class ResearchesController : Controller
    {
        private readonly IMainRepository _db;
        private readonly IWebHostEnvironment _webHost;

        public ResearchesController(IMainRepository db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._researchRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _db._researchRepository.GetAsync(expression: m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Research research, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                research.PDF = file;

                await _db._researchRepository.CreateAsync(research);
                return RedirectToAction(nameof(Index));
            }
            return View(research);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _db._researchRepository.GetAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }
            return View(research);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Research research, IFormFile file)
        {
            if (id != research.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    research.PDF = file;

                    var oldEntity = await _db._researchRepository.GetAsync(m => m.Id == id);

                    await _db._researchRepository.UpdateAsync(research, oldEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._researchRepository.GetAsync(m => m.Id == id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(research);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var research = await _db._researchRepository.GetAsync(m => m.Id == id);
            if (research == null)
            {
                return NotFound();
            }

            return View(research);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var research = await _db._researchRepository.GetAsync(m => m.Id == id);
            if (research != null)
            {
               await _db._researchRepository.DeleteAsync(research);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
