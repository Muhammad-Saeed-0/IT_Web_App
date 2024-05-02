using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class ProgramCoursesController : Controller
    {
        private readonly IMainRepository _db;

        public ProgramCoursesController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._programCoursesRepository.GetAllAsync(includeProperties: "EducationalProgram,Course"));
        }

        public async Task<IActionResult> Details(int progId, string courseCode)
        {
            if (progId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var programCourse = await _db._programCoursesRepository
                .GetAsync(
                expression: m => m.EducationalProgramId == progId && m.CourseCode == courseCode, 
                includeProperties: "EducationalProgram,Course");

            if (programCourse == null)
            {
                return NotFound();
            }

            return View(programCourse);
        }

        public IActionResult Create()
        {
            ViewData["CourseCode"] = new SelectList(_db._courseRepository.GetAll(), "Code", "CourseTitle");

            ViewData["EducationalProgramId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title");

            return View();          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgramCourse programCourse)
        {
            if (ModelState.IsValid)
            {
                await _db._programCoursesRepository.CreateAsync(programCourse);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseCode"] = new SelectList(_db._courseRepository.GetAll(), "Code", programCourse.CourseCode);

            ViewData["EducationalProgramId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title");

            return View(programCourse);
        }

        public async Task<IActionResult> Edit(int progId, string courseCode)
        {
            if (progId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var programCourse = await _db._programCoursesRepository
                .GetAsync(
                expression: m => m.EducationalProgramId == progId && m.CourseCode == courseCode,
                includeProperties: "EducationalProgram,Course");

            if (programCourse == null)
            {
                return NotFound();
            }

            return View(programCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int progId, string courseCode, ProgramCourse programCourse)
        {
            if (progId != programCourse.EducationalProgramId || courseCode != programCourse.CourseCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._programCoursesRepository.UpdateAsync(programCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._programCoursesRepository.GetAsync(m => m.EducationalProgramId == progId && m.CourseCode == courseCode) == null)
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

            return View(programCourse);
        }

        public async Task<IActionResult> Delete(int progId, string courseCode)
        {
            if (progId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var programCourse = await _db._programCoursesRepository
                .GetAsync(
                expression: m => m.EducationalProgramId == progId && m.CourseCode == courseCode,
                includeProperties: "Requirement,Course");

            if (programCourse == null)
            {
                return NotFound();
            }

            return View(programCourse);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int progId, string courseCode)
        {
            var programCourse = await _db._programCoursesRepository.GetAsync(m => m.EducationalProgramId == progId && m.CourseCode == courseCode);

            if (programCourse != null)
            {
                await _db._programCoursesRepository.DeleteAsync(programCourse);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
