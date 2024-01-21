using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly IMainRepository _db;
        private readonly IWebHostEnvironment _webHost;

        public EventsController(IMainRepository db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._eventRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _db._eventRepository.GetAsync(
                expression: m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event entity, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                entity.Image = image;

                await _db._eventRepository.CreateAsync(entity);
                return RedirectToAction(nameof(Index));
            }
            return View(entity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _db._eventRepository.GetAsync(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event entity, IFormFile image)
        {
            if (id != entity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    entity.Image = image;

                    var oldEntity = await _db._eventRepository.GetAsync(m => m.Id == id);

                    await _db._eventRepository.UpdateAsync(entity, oldEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._eventRepository.GetAsync(m => m.Id == id) == null)
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
            return View(entity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _db._eventRepository.GetAsync(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _db._eventRepository.GetAsync(m => m.Id == id);
            if (entity != null)
            {
                await _db._eventRepository.DeleteAsync(entity);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}