using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class EducationsController : Controller
    {
        private readonly IMainRepository _db;

        public EducationsController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = await _db._educationRepository.GetAllAsync(e => e.StaffId == id);
            return View(applicationDbContext);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _db._educationRepository.GetAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        public IActionResult Create(int staffId)
        {
            ViewData["StaffId"] = staffId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Education education)
        {
            if (ModelState.IsValid)
            {
                await _db._educationRepository.CreateAsync(education);
                return RedirectToAction(nameof(Details), "Staffs", new { id = education.StaffId });
            }

            ViewData["StaffId"] = education.StaffId;
            return View(education);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _db._educationRepository.GetAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = education.StaffId;
            return View(education);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Education education)
        {
            if (id != education.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._educationRepository.UpdateAsync(education);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._educationRepository.GetAsync(m => m.Id == id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Staffs", new { id = education.StaffId });
            }

            ViewData["StaffId"] = education.StaffId;
            return View(education);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _db._educationRepository.GetAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _db._educationRepository.GetAsync(m => m.Id == id);
            if (education != null)
            {
               await _db._educationRepository.DeleteAsync(education);
            }

            return RedirectToAction(nameof(Details), "Staffs", new { id = education.StaffId });
        }
    }
}
