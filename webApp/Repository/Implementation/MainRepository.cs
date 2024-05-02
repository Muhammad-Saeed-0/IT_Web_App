using webApp.Data;
using webApp.Repository.Contracts;

namespace webApp.Repository.Implementation
{
    public class MainRepository : IMainRepository
    {
        public MainRepository(ApplicationDbContext db, IWebHostEnvironment webHost)
        {
            _staffRepository = new StaffRepository(db, webHost);
            _educationRepository = new EducationRepository(db);
            _scientificAchievementRepository = new ScientificAchievementRepository(db);
            _staffLinkRepository = new StaffLinkRepository(db);
            _researchRepository = new ResearchRepository(db, webHost);
            _regulationRepository = new RegulationRepository(db);
            _courseRepository = new CourseRepository(db);
            _newsRepository = new NewsRepository(db, webHost);
            _newsImagesRepository = new NewsImagesRepository(db, webHost);
            _requirementRepository = new RequirementRepository(db);
            _requirementCoursesRepository = new RequirementCoursesRepository(db);
            _eventRepository = new EventRepository(db, webHost);
            _studyPlanRepository = new StudyPlanRepository(db);
            _studyPlanCoursesRepository = new StudyPlanCoursesRepository(db);
            _educationalProgramRepository = new EducationalProgramRepository(db);
            _programCoursesRepository = new ProgramCoursesRepository(db);
        }

        public IStaffRepository _staffRepository { get; private set; }
        public IEducationRepository _educationRepository { get; private set; }
        public IScientificAchievementRepository _scientificAchievementRepository { get; private set; }
        public IStaffLinkRepository _staffLinkRepository { get; private set; }
        public IResearchRepository _researchRepository { get; private set; }
        public IRegulationRepository _regulationRepository { get; private set; }
        public ICourseRepository _courseRepository { get; private set; }
        public INewsRepository _newsRepository { get; private set; }
        public INewsImagesRepository _newsImagesRepository { get; private set; }
        public IRequirementRepository _requirementRepository { get; private set; }
        public IRequirementCoursesRepository _requirementCoursesRepository { get; private set; }
        public IEventRepository _eventRepository { get; private set; }
        public IStudyPlanRepository _studyPlanRepository { get; private set; }
        public IStudyPlanCoursesRepository _studyPlanCoursesRepository { get; private set; }
        public IEducationalProgramRepository _educationalProgramRepository { get; private set; }
        public IProgramCoursesRepository _programCoursesRepository { get; private set; }
    }
}
