using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class StaffLinksController : Controller
    {
        private readonly IMainRepository _db;

        public StaffLinksController(IMainRepository db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(int id)
        {
            var applicationDbContext = await _db._staffLinkRepository.GetAllAsync(e => e.StaffId == id);
            return View(applicationDbContext);
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staffLink = await _db._staffLinkRepository.GetAsync(m => m.Id == id);
        //    if (staffLink == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(staffLink);
        //}

        public IActionResult Create(int staffId)
        {
            ViewData["StaffId"] = staffId;
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffLink staffLink)
        {
            if (ModelState.IsValid)
            {
                await _db._staffLinkRepository.CreateAsync(staffLink);
                return RedirectToAction("Details", "Staffs", new { id = staffLink.StaffId });
            }

            ViewData["StaffId"] = staffLink.StaffId;
            return View(staffLink);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffLink = await _db._staffLinkRepository.GetAsync(m => m.Id == id);
            if (staffLink == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = staffLink.StaffId;
            return View(staffLink);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StaffLink staffLink)
        {
            if (id != staffLink.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _db._staffLinkRepository.UpdateAsync(staffLink);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._staffLinkRepository.GetAsync(m => m.Id == id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Staffs", new { id = staffLink.StaffId });
            }

            ViewData["StaffId"] = staffLink.StaffId;
            return View(staffLink);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffLink = await _db._staffLinkRepository.GetAsync(m => m.Id == id);
            if (staffLink == null)
            {
                return NotFound();
            }

            return View(staffLink);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffLink = await _db._staffLinkRepository.GetAsync(m => m.Id == id);
            if (staffLink != null)
            {
               await _db._staffLinkRepository.DeleteAsync(staffLink);
            }

            return RedirectToAction("Details", "Staffs", new { id = staffLink.StaffId });
        }
    }
}
