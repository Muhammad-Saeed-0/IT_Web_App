using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class StudyPlanProgramLevelsController : Controller
    {
        private readonly IMainRepository _db;

        public StudyPlanProgramLevelsController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._planPLRepository.GetAllAsync(includeProperties: "EducationalProgram"));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _db._planPLRepository.GetAsync(
                r => r.Id == id,
                includeProperties: "ProgramLevelCourses,EducationalProgram");

            if (studyPlan == null)
            {
                return NotFound();
            }

            if (studyPlan.ProgramLevelCourses != null && studyPlan.ProgramLevelCourses.Count > 0)
            {
                foreach (var item in studyPlan.ProgramLevelCourses)
                {
                    item.Course = await _db._courseRepository.GetAsync(m => m.Code == item.CourseCode);
                }
            }

            return View(studyPlan);
        }

        public IActionResult Create()
        {
            ViewData["EducationalProgramId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title");

            ViewBag.Courses = _db._courseRepository.GetAll().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudyPlanProgramLevel studyPlan, string[] selectedCourses, string[] SemesterOne, string[] SemesterTwo)
        {
            if (ModelState.IsValid)
            {
                await _db._planPLRepository.CreateAsync(studyPlan);

                if (selectedCourses != null)
                {
                    var stuCourse = new ProgramLevelCourse();
                    int c1 = 0;
                    int c2 = 0;

                    foreach (var item in selectedCourses)
                    {
                        stuCourse.StudyPlanProgramLevelId = studyPlan.Id;
                        stuCourse.CourseCode = item;

                        if (c1 < SemesterOne.Length && SemesterOne[c1] == stuCourse.CourseCode)
                        {
                            stuCourse.SemesterOne = true;
                            stuCourse.SemesterTwo = false;
                            ++c1;
                        }
                        else if (c2 < SemesterTwo.Length && SemesterTwo[c2] == stuCourse.CourseCode)
                        {
                            stuCourse.SemesterTwo = true;
                            stuCourse.SemesterOne = false;
                            ++c2;
                        }

                        await _db._pLCourseRepository.CreateAsync(stuCourse);
                    }

                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["EducationalProgramId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title", studyPlan.EducationalProgramId);

            return View(studyPlan);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _db._planPLRepository.GetAsync(s => s.Id == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            ViewData["EducationalProgramId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title", studyPlan.EducationalProgramId);

            return View(studyPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudyPlanProgramLevel studyPlan)
        {
            if (id != studyPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._planPLRepository.UpdateAsync(studyPlan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._planELRepository.GetAsync(m => m.Id == studyPlan.Id) == null)
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

            ViewData["EducationalProgramId"] = new SelectList(_db._educationalProgramRepository.GetAll(), "Id", "Title", studyPlan.EducationalProgramId);

            return View(studyPlan);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _db._planPLRepository.GetAsync(m => m.Id == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            return View(studyPlan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studyPlan = await _db._planPLRepository.GetAsync(m => m.Id == id);
            if (studyPlan != null)
            {
                await _db._planPLRepository.DeleteAsync(studyPlan);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
