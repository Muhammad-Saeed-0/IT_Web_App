using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class CourseRepository(ApplicationDbContext db) : BaseRepository<Course>(db), ICourseRepository { }
}
