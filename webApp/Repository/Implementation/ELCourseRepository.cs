using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class ELCourseRepository(ApplicationDbContext db) : BaseRepository<EntryLevelCourse>(db), IELCourseRepository { }
}
