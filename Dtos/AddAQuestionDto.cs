namespace CapitalPlacementTask.Dtos
{
    public class AddAQuestionDto
    {
        public string QuestionType { get; set; }

        public string? ParagraphQuestion { get; set; }
        public string? YesOrNo { get; set; }

        public MultipleChoiceQuestionsDto? MultipleChoiceQuestions { get; set; }
        public DropDownDto? DropDown { get; set; }
    }

    public class MultipleChoiceQuestionsDto
    {

        public string Question { get; set; }
        public List<string> Choice { get; set; }
        public bool EnableOtherOption { get; set; }
        public int MaxChoiceAllowed { get; set; }



    }
    public class DropDownDto : MultipleChoiceQuestionsDto
    {

    }
}
