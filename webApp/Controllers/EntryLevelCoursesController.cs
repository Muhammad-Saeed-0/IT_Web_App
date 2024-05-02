using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class EntryLevelCoursesController : Controller
    {
        private readonly IMainRepository _db;

        public EntryLevelCoursesController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._eLCourseRepository.GetAllAsync(includeProperties: "StudyPlanEntryLevel,Course"));
        }

        public async Task<IActionResult> Details(int studyPlanId, string courseCode)
        {
            if (studyPlanId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var studyPlanCourse = await _db._eLCourseRepository
                .GetAsync(
                expression: m => m.StudyPlanEntryLevelId == studyPlanId &&
                    m.CourseCode == courseCode,

                includeProperties: "StudyPlanEntryLevel,Course");

            if (studyPlanCourse == null)
            {
                return NotFound();
            }

            return View(studyPlanCourse);

        }

        public IActionResult Create()
        {
            ViewData["CourseCode"] = new SelectList(_db._courseRepository.GetAll(), "Code", "CourseTitle");
            ViewData["StudyPlanId"] = new SelectList(_db._planELRepository.GetAll(), "Id", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntryLevelCourse studyPlanCourse)
        {
            if (ModelState.IsValid)
            {
                await _db._eLCourseRepository.CreateAsync(studyPlanCourse);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseCode"] = new SelectList(_db._courseRepository.GetAll(), "Code", "CourseTitle", studyPlanCourse.CourseCode);

            ViewData["StudyPlanId"] = new SelectList(_db._planELRepository.GetAll(), "Id", "Title", studyPlanCourse.StudyPlanEntryLevelId);

            return View(studyPlanCourse);
        }

        public async Task<IActionResult> Edit(int studyPlanId, string courseCode)
        {
            if (studyPlanId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var studyPlanCourse = await _db._eLCourseRepository
                .GetAsync(
                expression: m => m.StudyPlanEntryLevelId == studyPlanId && m.CourseCode == courseCode,
                includeProperties: "StudyPlanEntryLevel,Course");

            if (studyPlanCourse == null)
            {
                return NotFound();
            }


            return View(studyPlanCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int studyPlanId, string courseCode, EntryLevelCourse studyPlanCourse)
        {
            if (studyPlanId != studyPlanCourse.StudyPlanEntryLevelId || courseCode != studyPlanCourse.CourseCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._eLCourseRepository.UpdateAsync(studyPlanCourse);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._eLCourseRepository.GetAsync(m => m.StudyPlanEntryLevelId == studyPlanId && m.CourseCode == courseCode) == null)
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

            var studyPlanCourse = await _db._eLCourseRepository
                .GetAsync(
                expression: m => m.StudyPlanEntryLevelId == studyPlanId && m.CourseCode == courseCode,
                includeProperties: "StudyPlanEntryLevel,Course");

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
            var studyPlanCourse = await _db._eLCourseRepository
                .GetAsync(expression: m => m.StudyPlanEntryLevelId == studyPlanId && m.CourseCode == courseCode);

            if (studyPlanCourse != null)
            {
                await _db._eLCourseRepository.DeleteAsync(studyPlanCourse);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
