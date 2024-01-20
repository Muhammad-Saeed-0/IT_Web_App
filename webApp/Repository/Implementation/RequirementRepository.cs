using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class RequirementRepository(ApplicationDbContext db) : BaseRepository<Requirement>(db), IRequirementRepository { }
}
