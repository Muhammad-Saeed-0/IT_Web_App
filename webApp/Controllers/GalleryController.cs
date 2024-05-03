using Microsoft.AspNetCore.Mvc;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IMainRepository _db;
        private readonly IWebHostEnvironment _webHost;

        public GalleryController(IMainRepository db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._galleryRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _db._galleryRepository.GetAsync(
                expression: m => m.Id == id);

            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> images)
        {
            if (ModelState.IsValid)
            {
                if (images != null)
                {
                    foreach (var item in images)
                    {
                        var img = new Gallery
                        {
                            Image = item
                        };

                        await _db._galleryRepository.CreateAsync(img);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _db._galleryRepository.GetAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _db._galleryRepository.GetAsync(m => m.Id == id);
            if (image != null)
            {
               await _db._galleryRepository.DeleteAsync(image);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
