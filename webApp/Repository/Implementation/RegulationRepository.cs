using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class RegulationRepository(ApplicationDbContext db) : BaseRepository<Regulation>(db), IRegulationRepository { }
}
