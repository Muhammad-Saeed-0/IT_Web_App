using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;
using webApp.Utility;

namespace webApp.Repository.Implementation
{
    public class ResearchRepository : BaseRepository<Research>, IResearchRepository
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public ResearchRepository(ApplicationDbContext db, IWebHostEnvironment webHost) : base(db)
        {
            _db = db;
            _webHost = webHost;
        }

        public override async Task CreateAsync(Research entity)
        {
            if (entity.PDF != null && entity.PDF.Length > 0)
            {
                var path = CreateFile.CreateFiles(_webHost, entity.PDF, "pdfs\\researches");
                entity.PdfUrl = path;
            }

            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public override async Task<Research> UpdateAsync(Research entity, Research oldEntity)
        {
            if (entity.PDF != null && entity.PDF.Length > 0)
            {
                if (oldEntity?.PdfUrl != null)
                {
                    var oldPath = _webHost.WebRootPath + oldEntity.PdfUrl.Replace("/", "\\");

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var path = CreateFile.CreateFiles(_webHost, entity.PDF, "pdfs\\researches");
                entity.PdfUrl = path;
            }

            _dbSet.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public override async Task DeleteAsync(Research entity)
        {
            if (entity.PdfUrl != null)
            {
                var oldPath = _webHost.WebRootPath + entity.PdfUrl.Replace("/", "\\");
               
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
