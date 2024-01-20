using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;
using webApp.Utility;

namespace webApp.Repository.Implementation
{
    public class NewsImagesRepository : BaseRepository<NewsImages>, INewsImagesRepository
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public NewsImagesRepository(ApplicationDbContext db, IWebHostEnvironment webHost) : base(db)
        {
            _db = db;
            _webHost = webHost;
        }

        public override async Task CreateAsync(NewsImages entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            if (entity.Image != null && entity.Image.Length > 0)
            {
                var path = CreateFile.CreateFiles(_webHost, entity.Image, "images\\news\\" + entity.NewsId);

                entity.ImageUrl = path;
            }

            await _db.SaveChangesAsync();
        }

        public override async Task<NewsImages> UpdateAsync(NewsImages entity, NewsImages oldEntity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();

            if (entity.Image != null && entity.Image.Length > 0)
            {
                if (oldEntity?.ImageUrl != null)
                {
                    var oldPath = _webHost.WebRootPath + oldEntity.ImageUrl;

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var path = CreateFile.CreateFiles(_webHost, entity.Image, "images\\news\\" + entity.NewsId);

                entity.ImageUrl = path;
            }

            await _db.SaveChangesAsync();

            return entity;
        }

        //public override async Task DeleteAsync(NewsImages entity)
        //{
        //    if (entity.MainImageUrl != null)
        //    {
        //        var oldPath = _webHost.WebRootPath + entity.MainImageUrl;

        //        if (File.Exists(oldPath))
        //        {
        //            File.Delete(oldPath);
        //        }
        //    }

        //    _dbSet.Remove(entity);
        //    await _db.SaveChangesAsync();
        //}
    }
}
