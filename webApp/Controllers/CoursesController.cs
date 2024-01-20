using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IMainRepository _db;

        public CoursesController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._courseRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var course = await _db._courseRepository.GetAsync(expression: m => m.Code == code);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _db._courseRepository.CreateAsync(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Edit(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var course = await _db._courseRepository.GetAsync(m => m.Code == code);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string code, Course course)
        {
            if (code != course.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldEntity = await _db._courseRepository.GetAsync(m => m.Code == code);

                    await _db._courseRepository.UpdateAsync(course, oldEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._courseRepository.GetAsync(m => m.Code == code) == null)
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
            return View(course);
        }

        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var course = await _db._courseRepository.GetAsync(m => m.Code == code);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string code)
        {
            var course = await _db._courseRepository.GetAsync(m => m.Code == code);
            if (course != null)
            {
                await _db._courseRepository.DeleteAsync(course);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
