using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;
using webApp.Utility;

namespace webApp.Repository.Implementation
{
    public class GalleryRepository : BaseRepository<Gallery>, IGalleryRepository
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public GalleryRepository(ApplicationDbContext db, IWebHostEnvironment webHost) : base(db)
        {
            _db = db;
            _webHost = webHost;
        }

        public override async Task CreateAsync(Gallery entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            if (entity.Image != null && entity.Image.Length > 0)
            {
                var path = CreateFile.CreateFiles(_webHost, entity.Image, "images\\gallery");
                entity.ImgUrl = path;
            }

            await _db.SaveChangesAsync();
        }

        public override async Task<Gallery> UpdateAsync(Gallery entity, Gallery oldEntity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();

            if (entity.Image != null && entity.Image.Length > 0)
            {
                if (oldEntity?.ImgUrl != null)
                {
                    var oldPath = _webHost.WebRootPath + oldEntity.ImgUrl;

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var path = CreateFile.CreateFiles(_webHost, entity.Image, "images\\gallery");
                entity.ImgUrl = path;
            }
            else
            {
                entity.ImgUrl = oldEntity.ImgUrl;
            }

            await _db.SaveChangesAsync();
            return entity;
        }

        public override async Task DeleteAsync(Gallery entity)
        {
            if (entity.ImgUrl != null)
            {
                var oldPath = _webHost.WebRootPath + entity.ImgUrl;
               
                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }
            }

            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
