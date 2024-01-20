using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Data;
using webApp.Models;
using webApp.Repository.Contracts;
using webApp.Utility;

namespace webApp.Controllers
{
    public class StaffsController : Controller
    {
        private readonly IMainRepository _db;
        private readonly IWebHostEnvironment _webHost;

        public StaffsController(IMainRepository db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._staffRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _db._staffRepository.GetAsync(
                expression: m => m.Id == id, includeProperties: "Educations,ScientificAchievements,StaffLinks");
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Staff staff, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                staff.UserImage = image;

                await _db._staffRepository.CreateAsync(staff);
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _db._staffRepository.GetAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Staff staff, IFormFile image)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    staff.UserImage = image;

                    var oldEntity = await _db._staffRepository.GetAsync(m => m.Id == id);

                    await _db._staffRepository.UpdateAsync(staff, oldEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._staffRepository.GetAsync(m => m.Id == id) == null)
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
            return View(staff);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _db._staffRepository.GetAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _db._staffRepository.GetAsync(m => m.Id == id);
            if (staff != null)
            {
               await _db._staffRepository.DeleteAsync(staff);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
