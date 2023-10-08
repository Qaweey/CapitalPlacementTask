namespace CapitalPlacementTask.Dtos
{
    public class WorkFlowDto
    {

        public List<NewStageInfoDto> ListOfNewStageInfo { get; set; }
    }

    public class NewStageInfoDto
    {

        public string StageName { get; set; }
        public string StageType { get; set; }
        public VideoInterviewInfoDto? VideoInterviewInfo { get; set; }

    }
    public class VideoInterviewInfoDto
    {
        public string VideoInterviewQuestion { get; set; }
        public string AdditionalInfo { get; set; }
        public int MaxDurationOfVideo { get; set; }
        public int Deadline { get; set; }

    }
}
