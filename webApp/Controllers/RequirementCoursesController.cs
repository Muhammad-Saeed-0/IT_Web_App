﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class RequirementCoursesController : Controller
    {
        private readonly IMainRepository _db;

        public RequirementCoursesController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._requirementCoursesRepository.GetAllAsync(includeProperties: "Requirement,Course"));
        }

        public async Task<IActionResult> Details(int reqId, string courseCode)
        {
            if (reqId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var requirementCourse = await _db._requirementCoursesRepository
                .GetAsync(
                expression: m => m.RequirementId == reqId && 
                    m.CourseCode == courseCode, 
                
                includeProperties: "Requirement,Course");

            if (requirementCourse == null)
            {
                return NotFound();
            }

            return View(requirementCourse);
        }

        public IActionResult Create()
        {
            var courses = _db._courseRepository.GetAll();
            ViewData["CourseCode"] = new SelectList(courses, "Code", "CourseTitle");

            ViewData["RegulationId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title");

            return View();          
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RequirementCourse requirementCourse)
        {
            if (ModelState.IsValid)
            {
                await _db._requirementCoursesRepository.CreateAsync(requirementCourse);

                return RedirectToAction(nameof(Index));
            }

            var courses = _db._courseRepository.GetAll();
            ViewData["CourseCode"] = new SelectList(courses, "Code", requirementCourse.CourseCode);

            ViewData["RegulationId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title");

            return View(requirementCourse);
        }

        public async Task<IActionResult> Edit(int reqId, string courseCode)
        {
            if (reqId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var regulationCourse = await _db._requirementCoursesRepository
                .GetAsync(
                expression: m => m.RequirementId == reqId &&
                    m.CourseCode == courseCode,

                includeProperties: "Requirement,Course");

            if (regulationCourse == null)
            {
                return NotFound();
            }

            var courses = _db._courseRepository.GetAll();
            ViewData["CourseCode"] = new SelectList(courses, "Code", regulationCourse.CourseCode);

            ViewData["RegulationId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title");

            return View(regulationCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int reqId, string courseCode, RequirementCourse requirementCourse)
        {
            if (reqId != requirementCourse.RequirementId || courseCode != requirementCourse.CourseCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var oldEntity = await _db._requirementCoursesRepository.GetAsync(m => m.RequirementId == reqId && m.CourseCode == courseCode);

                    await _db._requirementCoursesRepository.UpdateAsync(requirementCourse, oldEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _db._requirementCoursesRepository.GetAsync(m => m.RequirementId == reqId && m.CourseCode == courseCode) == null)
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

            var courses = _db._courseRepository.GetAll();
            ViewData["CourseCode"] = new SelectList(courses, "Code", requirementCourse.CourseCode);

            ViewData["RegulationId"] = new SelectList(_db._requirementRepository.GetAll(), "Id", "Title");

            return View(requirementCourse);
        }

        public async Task<IActionResult> Delete(int reqId, string courseCode)
        {
            if (reqId == 0 || courseCode == null)
            {
                return NotFound();
            }

            var regulationCourse = await _db._requirementCoursesRepository
                .GetAsync(
                expression: m => m.RequirementId == reqId &&
                    m.CourseCode == courseCode,

                includeProperties: "Requirement,Course"); ;

            if (regulationCourse == null)
            {
                return NotFound();
            }

            return View(regulationCourse);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int reqId, string courseCode)
        {
            var regulationCourse = await _db._requirementCoursesRepository.GetAsync(m => m.RequirementId == reqId && m.CourseCode == courseCode);

            if (regulationCourse != null)
            {
                await _db._requirementCoursesRepository.DeleteAsync(regulationCourse);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
