namespace McqExaminationSystem.dto
{
    public class examQuestionsdto
    {
        public int ExamId { get; set; }
        public long QuestionId { get; set; }
        public string QuestionHeader { get; set; }
        public string QuestionFirstChoice { get; set; }
        public string QuestionSecondChoice { get; set; }
        public string QuestionThirdChoice { get; set; }
        public string QuestionFourthChoice { get; set; }
        public string RightAnswer { get; set; }

    }
}
