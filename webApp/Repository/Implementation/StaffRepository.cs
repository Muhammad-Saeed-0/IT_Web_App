using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;
using webApp.Utility;

namespace webApp.Repository.Implementation
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        private ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHost;

        public StaffRepository(ApplicationDbContext db, IWebHostEnvironment webHost) : base(db)
        {
            _db = db;
            _webHost = webHost;
        }

        public override async Task CreateAsync(Staff entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            if (entity.UserImage != null && entity.UserImage.Length > 0)
            {
                var path = CreateFile.CreateFiles(_webHost, entity.UserImage, "images\\staff_img");
                entity.PersonalImgUrl = path;
            }

            await _db.SaveChangesAsync();
        }

        public override async Task<Staff> UpdateAsync(Staff entity, Staff oldEntity)
        {
            _dbSet.Update(entity);
            await _db.SaveChangesAsync();

            if (entity.UserImage != null && entity.UserImage.Length > 0)
            {
                if (oldEntity?.PersonalImgUrl != null)
                {
                    //var oldPath = _webHost.WebRootPath + oldEntity.PersonalImgUrl.Replace("/", "\\");
                    var oldPath = _webHost.WebRootPath + oldEntity.PersonalImgUrl;

                    if (File.Exists(oldPath))
                    {
                        File.Delete(oldPath);
                    }
                }

                var path = CreateFile.CreateFiles(_webHost, entity.UserImage, "images\\staff_img");
                entity.PersonalImgUrl = path;
            }
            else
            {
                entity.PersonalImgUrl = oldEntity.PersonalImgUrl;
            }

            await _db.SaveChangesAsync();
            return entity;
        }

        public override async Task DeleteAsync(Staff entity)
        {
            if (entity.PersonalImgUrl != null)
            {
                //var oldPath = _webHost.WebRootPath + entity.PersonalImgUrl.Replace("/", "\\");
                var oldPath = _webHost.WebRootPath + entity.PersonalImgUrl;
               
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
