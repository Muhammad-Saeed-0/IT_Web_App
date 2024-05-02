using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class EducationalProgramRepository(ApplicationDbContext db) : BaseRepository<EducationalProgram>(db), IEducationalProgramRepository { }
}
