using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly IMainRepository _db;

        public RequirementsController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._requirementRepository.GetAllAsync(includeProperties: "Regulation"));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _db._requirementRepository.GetAsync(
                r => r.Id == id, 
                includeProperties: "RequirementCourses,Regulation");

            if (requirement.RequirementCourses != null && requirement.RequirementCourses.Count > 0)
            {
                foreach (var item in requirement.RequirementCourses)
                {
                    item.Course = await _db._courseRepository.GetAsync(m => m.Code == item.CourseCode);
                }
            }

            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        public IActionResult Create()
        {
            ViewData["RegulationCode"] = new SelectList(_db._regulationRepository.GetAll(), "Code", "Title");

            ViewBag.Courses = _db._courseRepository.GetAll().ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Requirement requirement, string[] selectedCourses, string[] isCompulsory)
        {
            if (ModelState.IsValid)
            {
                await _db._requirementRepository.CreateAsync(requirement);

                if (selectedCourses != null)
                {
                    var reqCourse = new RequirementCourse();
                    int c = 0;

                    foreach (var item in selectedCourses)
                    {
                        reqCourse.RequirementId = requirement.Id;
                        reqCourse.CourseCode = item;

                        if (c < isCompulsory.Length && isCompulsory[c] != null)
                        {
                            reqCourse.IsCompulsory = true;
                            ++c;
                        }
                        else
                        {
                            reqCourse.IsCompulsory = false;
                        }

                        await _db._requirementCoursesRepository.CreateAsync(reqCourse);
                    }

                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["RegulationCode"] = new SelectList(_db._regulationRepository.GetAll(), "Code", "Title", requirement.RegulationCode);

            return View(requirement);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _db._requirementRepository.GetAsync(
                r => r.Id == id);

            if (requirement == null)
            {
                return NotFound();
            }

            ViewData["RegulationCode"] = new SelectList(_db._regulationRepository.GetAll(), "Code", "Title", requirement.RegulationCode);

            return View(requirement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Requirement requirement)
        {
            if (id != requirement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _db._requirementRepository.UpdateAsync(requirement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._requirementRepository.GetAsync(m => m.Id == requirement.Id) == null)
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

            ViewData["RegulationCode"] = new SelectList(_db._regulationRepository.GetAll(), "Code", "Title", requirement.RegulationCode);

            return View(requirement);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requirement = await _db._requirementRepository.GetAsync(
                r => r.Id == id);

            if (requirement == null)
            {
                return NotFound();
            }

            return View(requirement);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requirement = await _db._requirementRepository.GetAsync(
                r => r.Id == id);

            if (requirement != null)
            {
                await _db._requirementRepository.DeleteAsync(requirement);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
