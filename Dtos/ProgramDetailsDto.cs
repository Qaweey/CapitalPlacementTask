namespace CapitalPlacementTask.Dtos
{
    public class ProgramDetailsDto
    {

        public string ProgramTitle { get; set; }
        public string SummaryOfProgram { get; set; }
        public string ProgramDescription { get; set; }
        public List<string> KeySkills { get; set; }
        public List<string> ProgramBenefit { get; set; }

        public List<string> ApplicationCriteria { get; set; }

        public AdditionalProgramInfoDto AdditionalProgramInfo { get; set; }
    }


    public class AdditionalProgramInfoDto
    {
        public string? ProgramType { get; set; }
        public DateTime ProgramStart { get; set; }

        public DateTime ApplicationOpen { get; set; }

        public DateTime ApplicationClose { get; set; }
        public string? Duration { get; set; }
        public string ProgramLocation { get; set; }

        public string MinQualification { get; set; }
        public double MaxNumberOfApplication { get; set; }





    }
}
