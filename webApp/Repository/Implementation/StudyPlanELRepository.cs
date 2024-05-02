using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class StudyPlanELRepository(ApplicationDbContext db) : BaseRepository<StudyPlanEntryLevel>(db), IStudyPlanELRepository { }
}
