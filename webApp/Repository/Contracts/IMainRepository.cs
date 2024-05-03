namespace webApp.Repository.Contracts
{
    public interface IMainRepository
    {
        IStaffRepository _staffRepository { get; }
        IEducationRepository _educationRepository { get; }
        IScientificAchievementRepository _scientificAchievementRepository { get; }
        IStaffLinkRepository _staffLinkRepository { get; }
        IResearchRepository _researchRepository { get; }
        IRegulationRepository _regulationRepository { get; }
        ICourseRepository _courseRepository { get; }
        INewsRepository _newsRepository { get; }
        INewsImagesRepository _newsImagesRepository { get; }
        IRequirementRepository _requirementRepository { get; }
        IRequirementCoursesRepository _requirementCoursesRepository { get; }
        IEventRepository _eventRepository { get; }
        IStudyPlanELRepository _planELRepository { get; }
        IELCourseRepository _eLCourseRepository { get; } 
        IStudyPlanPLRepository _planPLRepository { get; }
        IPLCourseRepository _pLCourseRepository { get; }
        IEducationalProgramRepository _educationalProgramRepository { get; }
        IProgramCoursesRepository _programCoursesRepository { get; }
        IGalleryRepository _galleryRepository { get; }
    }
}
