using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class ProgramLevelCoursesController : Controller
    {
        private readonly IMainRepository _db;

        public ProgramLevelCoursesController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._pLCourseRepository.GetAllAsync(includeProperties: "StudyPlanProgramLevel,Course"));
        }

        public async Task<IActionResult> Details(int studyPlanId, string courseCode)
        {
            if (studyPlanId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var requirementCourse = await _db._pLCourseRepository
                .GetAsync(
                expression: m => m.StudyPlanProgramLevelId == studyPlanId && m.CourseCode == courseCode,
                includeProperties: "StudyPlanProgramLevel,Course");

            if (requirementCourse == null)
            {
                return NotFound();
            }

            return View(requirementCourse);
        }

        public IActionResult Create()
        {
            ViewData["CourseCode"] = new SelectList(_db._courseRepository.GetAll(), "Code", "CourseTitle");
            ViewData["StudyPlanProgramLevelId"] = new SelectList(_db._planPLRepository.GetAll(), "Id", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProgramLevelCourse studyPlanCourse)
        {
            if (ModelState.IsValid)
            {
                await _db._pLCourseRepository.CreateAsync(studyPlanCourse);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseCode"] = new SelectList(_db._courseRepository.GetAll(), "Code", "CourseTitle", studyPlanCourse.CourseCode);

            ViewData["StudyPlanProgramLevelId"] = new SelectList(_db._planPLRepository.GetAll(), "Id", "Title", studyPlanCourse.StudyPlanProgramLevelId);

            return View(studyPlanCourse);
        }

        public async Task<IActionResult> Edit(int studyPlanId, string courseCode)
        {
            if (studyPlanId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var studyPlanCourse = await _db._pLCourseRepository
                .GetAsync(
                expression: m => m.StudyPlanProgramLevelId == studyPlanId && m.CourseCode == courseCode,
                includeProperties: "StudyPlanProgramLevel,Course");

            if (studyPlanCourse == null)
            {
                return NotFound();
            }


            return View(studyPlanCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int studyPlanId, string courseCode, ProgramLevelCourse studyPlanCourse)
        {
            if (studyPlanId != studyPlanCourse.StudyPlanProgramLevelId || courseCode != studyPlanCourse.CourseCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._pLCourseRepository.UpdateAsync(studyPlanCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._pLCourseRepository.GetAsync(m => m.StudyPlanProgramLevelId == studyPlanId && m.CourseCode == courseCode) == null)
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

            return View(studyPlanCourse);
        }

        public async Task<IActionResult> Delete(int studyPlanId, string courseCode)
        {
            if (studyPlanId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var studyPlanCourse = await _db._pLCourseRepository
                .GetAsync(
                expression: m => m.StudyPlanProgramLevelId == studyPlanId && m.CourseCode == courseCode,
                includeProperties: "StudyPlanProgramLevel,Course");

            if (studyPlanCourse == null)
            {
                return NotFound();
            }

            return View(studyPlanCourse);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int studyPlanId, string courseCode)
        {
            var studyPlanCourse = await _db._pLCourseRepository
                .GetAsync(expression: m => m.StudyPlanProgramLevelId == studyPlanId && m.CourseCode == courseCode);

            if (studyPlanCourse != null)
            {
                await _db._pLCourseRepository.DeleteAsync(studyPlanCourse);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
