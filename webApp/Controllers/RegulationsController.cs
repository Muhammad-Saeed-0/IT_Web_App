using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class RegulationsController : Controller
    {
        private readonly IMainRepository _db;

        public RegulationsController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._regulationRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var regulation = await _db._regulationRepository.GetAsync(
                expression: m => m.Code == code,
                includeProperties: "Requirements");

            if (regulation.Requirements != null && regulation.Requirements.Count > 0)
            {
                foreach (var item in regulation.Requirements)
                {
                    item.RequirementCourses = await _db._requirementCoursesRepository.GetAllAsync(
                        m => m.RequirementId == item.Id,
                        includeProperties: "Course");
                }
            }

            if (regulation == null)
            {
                return NotFound();
            }

            return View(regulation);
        }

        public IActionResult Create()
        {
            //ViewBag.Courses = _db._courseRepository.GetAll().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Regulation regulation/*, string[] selectedCourses, string[] isCompulsory*/)
        {
            if (ModelState.IsValid)
            {
                await _db._regulationRepository.CreateAsync(regulation);

                //if (selectedCourses != null)
                //{
                //    var regulationCourse = new RegulationCourse();
                //    int c = 0;
                //    foreach (var item in selectedCourses)
                //    {
                //        regulationCourse.RegulationCode = regulation.Code;
                //        regulationCourse.CourseCode = item;

                //        if (c < isCompulsory.Length && isCompulsory[c] != null)
                //        {
                //            regulationCourse.IsCompulsory = true;
                //            ++c;
                //        }
                //        else
                //        {
                //            regulationCourse.IsCompulsory = false;
                //        }

                //        await _db._regulationCoursesRepository.CreateAsync(regulationCourse);
                //    }

                //}

                return RedirectToAction(nameof(Index));
            }



            return View(regulation);
        }

        public async Task<IActionResult> Edit(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var regulation = await _db._regulationRepository.GetAsync(m => m.Code == code);
            if (regulation == null)
            {
                return NotFound();
            }
            return View(regulation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string code, Regulation regulation)
        {
            if (code != regulation.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldEntity = await _db._regulationRepository.GetAsync(m => m.Code == code);

                    await _db._regulationRepository.UpdateAsync(regulation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._regulationRepository.GetAsync(m => m.Code == code) == null)
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
            return View(regulation);
        }

        public async Task<IActionResult> Delete(string code)
        {
            if (code == null)
            {
                return NotFound();
            }

            var regulation = await _db._regulationRepository.GetAsync(m => m.Code == code);
            if (regulation == null)
            {
                return NotFound();
            }

            return View(regulation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string code)
        {
            var regulation = await _db._regulationRepository.GetAsync(m => m.Code == code);
            if (regulation != null)
            {
                await _db._regulationRepository.DeleteAsync(regulation);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
