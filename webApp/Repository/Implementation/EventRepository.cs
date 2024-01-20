using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;
using webApp.Utility;

namespace webApp.Repository.Implementation
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public EventRepository(ApplicationDbContext db, IWebHostEnvironment webHost) : base(db)
        {
            _db = db;
            _webHost = webHost;
        }

        public override async Task CreateAsync(Event entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            if (entity.Image != null && entity.Image.Length > 0)
            {
                var path = CreateFile.CreateFiles(_webHost, entity.Image, "images\\events");
                entity.ImgUrl = path;
            }

            await _db.SaveChangesAsync();
        }

        public override async Task<Event> UpdateAsync(Event entity, Event oldEntity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();

            if (entity.Image != null && entity.Image.Length > 0)
            {
                if (oldEntity?. ImgUrl != null)
                {
                    var oldPath = _webHost.WebRootPath + oldEntity.ImgUrl;

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var path = CreateFile.CreateFiles(_webHost, entity.Image, "images\\events");
                entity.ImgUrl = path;
            }
            else
            {
                entity.ImgUrl = oldEntity.ImgUrl;
            }

            await _db.SaveChangesAsync();
            return entity;
        }

        public override async Task DeleteAsync(Event entity)
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
