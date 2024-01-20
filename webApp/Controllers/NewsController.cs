using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly IMainRepository _db;
        private readonly IWebHostEnvironment _webHost;

        public NewsController(IMainRepository db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db._newsRepository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _db._newsRepository.GetAsync(
                expression: m => m.Id == id, includeProperties: "NewsImages");

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(News news, IFormFile image, List<IFormFile> images)
        {
            if (ModelState.IsValid)
            {
                news.MainImage = image;

                await _db._newsRepository.CreateAsync(news);

                if (images != null)
                {
                    foreach (var item in images)
                    {
                        var img = new NewsImages
                        {
                            NewsId = news.Id,
                            Image = item
                        };

                        await _db._newsImagesRepository.CreateAsync(img);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(news);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _db._newsRepository.GetAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, News news, IFormFile image, List<IFormFile> images)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    news.MainImage = image;

                    var oldEntity = await _db._newsRepository.GetAsync(m => m.Id == id);

                    await _db._newsRepository.UpdateAsync(news, oldEntity);

                    if (images != null)
                    {
                        foreach (var item in images)
                        {
                            var img = new NewsImages
                            {
                                NewsId = news.Id,
                                Image = item
                            };

                            await _db._newsImagesRepository.UpdateAsync(img);
                        }
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_db._newsRepository.GetAsync(m => m.Id == id) == null)
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
            return View(news);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _db._newsRepository.GetAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _db._newsRepository.GetAsync(m => m.Id == id);
            if (news != null)
            {
                await _db._newsRepository.DeleteAsync(news);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
