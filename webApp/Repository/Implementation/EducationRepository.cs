using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class EducationRepository(ApplicationDbContext db) : BaseRepository<Education>(db), IEducationRepository {}
}
