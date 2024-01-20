using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webApp.Data;
using webApp.Models;
using webApp.Repository.Contracts;

namespace webApp.Controllers
{
    public class NewsImagesController : Controller
    {
        private readonly IMainRepository _db;
        private readonly IWebHostEnvironment _webHost;

        public NewsImagesController(IMainRepository db, IWebHostEnvironment webHost)
        {
            _db = db;
            _webHost = webHost;
        }

       
        //public IActionResult Create()
        //{
        //    ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,ImageUrl,NewsId")] NewsImages newsImages)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(newsImages);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", newsImages.NewsId);
        //    return View(newsImages);
        //}
        
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var newsImages = await _context.NewsImages
        //        .Include(n => n.News)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (newsImages == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(newsImages);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var newsImages = await _context.NewsImages.FindAsync(id);
        //    if (newsImages != null)
        //    {
        //        _context.NewsImages.Remove(newsImages);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
