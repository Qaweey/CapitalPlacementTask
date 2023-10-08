namespace CapitalPlacementTask.Models
{
    public class AddAQuestion
    {
        public string QuestionType { get; set; }

        public string? ParagraphQuestion { get; set; }
        public string? YesOrNo { get; set; }

        public MultipleChoiceQuestions? MultipleChoiceQuestions { get; set; }
        public DropDown? DropDown { get; set; }
    }

    public class MultipleChoiceQuestions
    {

        public string Question { get; set; }
        public List<string> Choice { get; set; }
        public bool EnableOtherOption { get; set; }
        public int MaxChoiceAllowed { get; set; }



    }
    public class DropDown : MultipleChoiceQuestions
    {

    }
}
