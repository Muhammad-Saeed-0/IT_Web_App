using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class ScientificAchievementsController : Controller
    {
        private readonly IMainRepository _db;

        public ScientificAchievementsController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = await _db._scientificAchievementRepository.GetAllAsync(e => e.StaffId == id);
            return View(applicationDbContext);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scientific = await _db._scientificAchievementRepository.GetAsync(m => m.Id == id);
            if (scientific == null)
            {
                return NotFound();
            }

            return View(scientific);
        }

        public IActionResult Create(int staffId)
        {
            ViewData["StaffId"] = staffId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScientificAchievement scientific)
        {
            if (ModelState.IsValid)
            {
                await _db._scientificAchievementRepository.CreateAsync(scientific);
                return RedirectToAction(nameof(Details), "Staffs", new { id = scientific.StaffId });
            }

            ViewData["StaffId"] = scientific.StaffId;
            return View(scientific);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scientific = await _db._scientificAchievementRepository.GetAsync(m => m.Id == id);
            if (scientific == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = scientific.StaffId;
            return View(scientific);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ScientificAchievement scientific)
        {
            if (id != scientific.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._scientificAchievementRepository.UpdateAsync(scientific);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._scientificAchievementRepository.GetAsync(m => m.Id == id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Staffs", new { id = scientific.StaffId });
            }

            ViewData["StaffId"] = scientific.StaffId;
            return View(scientific);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scientific = await _db._scientificAchievementRepository.GetAsync(m => m.Id == id);
            if (scientific == null)
            {
                return NotFound();
            }

            return View(scientific);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scientific = await _db._scientificAchievementRepository.GetAsync(m => m.Id == id);
            if (scientific != null)
            {
               await _db._scientificAchievementRepository.DeleteAsync(scientific);
            }

            return RedirectToAction(nameof(Details), "Staffs", new { id = scientific.StaffId });
        }
    }
}
