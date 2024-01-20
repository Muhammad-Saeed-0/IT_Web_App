using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class ScientificAchievementRepository(ApplicationDbContext db) : BaseRepository<ScientificAchievement>(db), IScientificAchievementRepository { }
}
