namespace CapitalPlacementTask.Models
{
    public class WorkFlow
    {
        public string CustId { get; set; }
        public List<NewStageInfo> ListOfNewStageInfo { get; set; }
    }

    public class NewStageInfo
    {

        public string StageName { get; set; }
        public string StageType { get; set; }
        public VideoInterviewInfo? VideoInterviewInfo { get; set; }

    }
    public class VideoInterviewInfo
    {
        public string VideoInterviewQuestion { get; set; }
        public string AdditionalInfo { get; set; }
        public int MaxDurationOfVideo { get; set; }
        public int Deadline { get; set; }

    }
}
