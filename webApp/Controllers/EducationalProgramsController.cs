using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class EducationalProgramsController : Controller
    {
        private readonly IMainRepository _db;

        public EducationalProgramsController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._educationalProgramRepository.GetAllAsync(includeProperties: "Requirement"));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _db._educationalProgramRepository.GetAsync(
                r => r.Id == id, 
                includeProperties: "Requirement,ProgramCourses");

            if (requirement == null)
            {
                return NotFound();
            }

            if (requirement.ProgramCourses != null && requirement.ProgramCourses.Count > 0)
            {
                foreach (var item in requirement.ProgramCourses)
                {
                    item.Course = await _db._courseRepository.GetAsync(m => m.Code == item.CourseCode);
                }
            }

            return View(requirement);
        }

        public IActionResult Create()
        {
            ViewData["RequirementId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title");

            ViewBag.Courses = _db._courseRepository.GetAll().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EducationalProgram educationalProgram, string[] selectedCourses, string[] isCompulsory)
        {
            if (ModelState.IsValid)
            {
                await _db._educationalProgramRepository.CreateAsync(educationalProgram);

                if (selectedCourses != null)
                {
                    var progCourse = new ProgramCourse();
                    int c = 0;

                    foreach (var item in selectedCourses)
                    {
                        progCourse.EducationalProgramId = educationalProgram.Id;
                        progCourse.CourseCode = item;

                        if (c < isCompulsory.Length && isCompulsory[c] == progCourse.CourseCode)
                        {
                            progCourse.IsCompulsory = true;
                            ++c;
                        }
                        else
                        {
                            progCourse.IsCompulsory = false;
                        }

                        await _db._programCoursesRepository.CreateAsync(progCourse);
                    }

                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["RequirementId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title", educationalProgram.RequirementId);

            return View(educationalProgram);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalProgram = await _db._educationalProgramRepository.GetAsync(
                r => r.Id == id);

            if (educationalProgram == null)
            {
                return NotFound();
            }

            ViewData["RequirementId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title", educationalProgram.RequirementId);

            return View(educationalProgram);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EducationalProgram educationalProgram)
        {
            if (id != educationalProgram.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _db._educationalProgramRepository.UpdateAsync(educationalProgram);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._educationalProgramRepository.GetAsync(m => m.Id == educationalProgram.Id) == null)
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

            ViewData["RegulationId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title", educationalProgram.RequirementId);

            return View(educationalProgram);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationalProgram = await _db._educationalProgramRepository.GetAsync(
                r => r.Id == id);

            if (educationalProgram == null)
            {
                return NotFound();
            }

            return View(educationalProgram);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationalProgram = await _db._educationalProgramRepository.GetAsync(
                r => r.Id == id);

            if (educationalProgram != null)
            {
                await _db._educationalProgramRepository.DeleteAsync(educationalProgram);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
