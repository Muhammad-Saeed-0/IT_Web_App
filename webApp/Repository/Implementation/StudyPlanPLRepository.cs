using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class StudyPlanPLRepository(ApplicationDbContext db) : BaseRepository<StudyPlanProgramLevel>(db), IStudyPlanPLRepository { }
}
