namespace CapitalPlacementTask.Dtos
{
    public class ApplicationFormDto
    {

        public string UploadCoverImage { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; }
        public ProfileDto ProfileInfo { get; set; }
        public AdditionalQuestionsDto AdditionalQuestionsInfo { get; set; }

    }

    public class PersonalInformationDto : AddAQuestionDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

    }

    public class ProfileDto : AddAQuestionDto
    {
        public List<EducationDto> EducationInfos { get; set; } = new();

        public List<WorkExperienceDto> WorkExperience { get; set; } = new();
        public string Resume { get; set; }


    }

    public class EducationDto
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string LocationOfStudy { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }

    public class WorkExperienceDto
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }

    // 
    public class AdditionalQuestionsDto : AddAQuestionDto
    {
        public string ParagraphQuestion { get; set; }
        public string GraduationYear { get; set; }
        public string Question { get; set; }

        public List<string> Choice { get; set; }
        public string YesOrNo { get; set; }
    }
}
