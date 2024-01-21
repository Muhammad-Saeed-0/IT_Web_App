using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class StudyPlanRepository(ApplicationDbContext db) : BaseRepository<StudyPlan>(db), IStudyPlanRepository { }
}
