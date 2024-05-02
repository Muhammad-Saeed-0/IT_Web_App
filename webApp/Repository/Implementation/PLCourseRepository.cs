using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class PLCourseRepository(ApplicationDbContext db) : BaseRepository<ProgramLevelCourse>(db), IPLCourseRepository { }
}
