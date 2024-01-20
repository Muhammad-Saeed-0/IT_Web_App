using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class StaffLinkRepository(ApplicationDbContext db) : BaseRepository<StaffLink>(db), IStaffLinkRepository { }
}
