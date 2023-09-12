using System.ComponentModel.DataAnnotations;

namespace McqExaminationSystem.DTO
{
    public class QuestionWithExam
    {
        public int Id { get; set; }
        public string QuestionHeader { get; set; }
        public string QuestionFirstChoice { get; set; }
        public string QuestionSecondChoice { get; set; }
        public string QuestionThirdChoice { get; set; }
        public string QuestionFourthChoice { get; set; }
        public string RightAnswer { get; set; }
        public int ExamId { get; set; }
        public string ExamName { get; set; }
    }
}
