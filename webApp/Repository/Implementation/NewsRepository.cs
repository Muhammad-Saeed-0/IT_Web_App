using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;
using webApp.Utility;

namespace webApp.Repository.Implementation
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public NewsRepository(ApplicationDbContext db, IWebHostEnvironment webHost) : base(db)
        {
            _db = db;
            _webHost = webHost;
        }

        public override async Task CreateAsync(News entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            if (entity.MainImage != null && entity.MainImage.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), (@"wwwroot\images\news\" + entity.Id));

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var path = CreateFile.CreateFiles(_webHost, entity.MainImage, "images\\news\\" + entity.Id);

                entity.MainImageUrl = path;
            }

            await _db.SaveChangesAsync();
        }

        public override async Task<News> UpdateAsync(News entity, News oldEntity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();

            if (entity.MainImage != null && entity.MainImage.Length > 0)
            {
                if (oldEntity?.MainImageUrl != null)
                {
                    var oldPath = _webHost.WebRootPath + oldEntity.MainImageUrl;

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), (@"wwwroot\images\news\" + entity.Id));

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                var path = CreateFile.CreateFiles(_webHost, entity.MainImage, "images\\news\\" + entity.Id);

                entity.MainImageUrl = path;
            }
            else
            {
                entity.MainImageUrl = oldEntity.MainImageUrl;
            }

            await _db.SaveChangesAsync();

            return entity;
        }

        public override async Task DeleteAsync(News entity)
        {
            if (entity.MainImageUrl != null)
            {
                var temp = (entity.MainImageUrl).Split("\\");
                var oldPath = _webHost.WebRootPath + string.Join("\\", temp, 0, temp.Length - 1);

                if (Directory.Exists(oldPath))
                {
                    Directory.Delete(oldPath, true);
                }
            }

            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
