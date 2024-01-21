using webApp.Data;
using webApp.Repository.Contracts;
using webApp.Models;

namespace webApp.Repository.Implementation
{
    public class StudyPlanCoursesRepository(ApplicationDbContext db) : BaseRepository<StudyPlanCourse>(db), IStudyPlanCoursesRepository { }
}
