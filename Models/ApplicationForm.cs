namespace CapitalPlacementTask.Models
{
    public class ApplicationForm
    {
        public string CustId { get; set; }
        public string UploadCoverImage { get; set; }
        public PersonalInformation PersonalInfo { get; set; }
        public Profiles ProfileInfo { get; set; }
        public AdditionalQuestions AdditionalQuestionsInfo { get; set; }

    }

    public class PersonalInformation : AddAQuestion
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

    public class Profiles : AddAQuestion
    {
        public List<Education> EducationInfos { get; set; } = new();

        public List<WorkExperience> WorkExperience { get; set; } = new();
        public string Resume { get; set; }


    }

    public class Education
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public string CourseName { get; set; }
        public string LocationOfStudy { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

    }

    public class WorkExperience
    {
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }


    }

    // 
    public class AdditionalQuestions : AddAQuestion
    {
        public string ParagraphQuestion { get; set; }
        public string GraduationYear { get; set; }
        public string Question { get; set; }

        public List<string> Choice { get; set; }
        public string YesOrNo { get; set; }
    }
}
