using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class StudyPlansController : Controller
    {
        private readonly IMainRepository _db;

        public StudyPlansController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._studyPlanRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _db._studyPlanRepository.GetAsync(
                m => m.Id == id,
                includeProperties: "StudyPlanCourses");

            if (studyPlan == null)
            {
                return NotFound();
            }

            if (studyPlan.StudyPlanCourses != null && studyPlan.StudyPlanCourses.Count > 0)
            {
                foreach (var item in studyPlan.StudyPlanCourses)
                {
                    item.Course = await _db._courseRepository.GetAsync(m => m.Code == item.CourseCode);
                }
            }

            return View(studyPlan);
        }

        public IActionResult Create()
        {
            ViewBag.Courses = _db._courseRepository.GetAll().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudyPlan studyPlan, string[] selectedCourses, string[] SemesterOne, string[] SemesterTwo)
        {
            if (ModelState.IsValid)
            {
                await _db._studyPlanRepository.CreateAsync(studyPlan);

                if (selectedCourses != null)
                {
                    var stuCourse = new StudyPlanCourse();
                    int c1 = 0;
                    int c2 = 0;

                    foreach (var item in selectedCourses)
                    {
                        stuCourse.StudyPlanId = studyPlan.Id;
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

                        await _db._studyPlanCoursesRepository.CreateAsync(stuCourse);
                    }

                }

                return RedirectToAction(nameof(Index));
            }

            return View(studyPlan);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _db._studyPlanRepository.GetAsync(s => s.Id == id);
            if (studyPlan == null)
            {
                return NotFound();
            }

            return View(studyPlan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StudyPlan studyPlan)
        {
            if (id != studyPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._studyPlanRepository.UpdateAsync(studyPlan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._studyPlanRepository.GetAsync(m => m.Id == studyPlan.Id) == null)
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
            return View(studyPlan);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studyPlan = await _db._studyPlanRepository.GetAsync(m => m.Id == id);
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
            var studyPlan = await _db._studyPlanRepository.GetAsync(m => m.Id == id);
            if (studyPlan != null)
            {
                await _db._studyPlanRepository.DeleteAsync(studyPlan);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
