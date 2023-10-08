namespace CapitalPlacementTask.Dtos
{
    public class SummaryDataDto
    {
        public string UserId { get; set; }
        public ProgramDetailsDto ProgramDetailsInfo { get; set; }

        public ApplicationFormDto applicationFormInfo { get; set; }

        public WorkFlowDto WorkFlowInfo { get; set; }
    }
}
