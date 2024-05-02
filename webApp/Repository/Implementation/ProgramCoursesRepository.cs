using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class ProgramCoursesRepository(ApplicationDbContext db) : BaseRepository<ProgramCourse>(db), IProgramCoursesRepository { }
}
