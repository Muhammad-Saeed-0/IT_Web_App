using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class RequirementCoursesRepository(ApplicationDbContext db) : BaseRepository<RequirementCourse>(db), IRequirementCoursesRepository { }
}
