using McqExaminationSystem.DTO;
using McqExaminationSystem.Models;
using McqExaminationSystem.Repositories.QuestionRepository;
using Microsoft.AspNetCore.Mvc;

namespace McqExaminationSystem.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _repository;

        public QuestionController(IQuestionRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("insert")]
        public ActionResult InsertQuestion(QuestionWithExam question)
        {
            if (ModelState.IsValid)
            {
                var question2 = new Question
                {
                    QuestionHeader = question.QuestionHeader,
                    QuestionFirstChoice = question.QuestionFirstChoice,
                    QuestionSecondChoice = question.QuestionSecondChoice,
                    QuestionThirdChoice = question.QuestionThirdChoice,
                    QuestionFourthChoice = question.QuestionFourthChoice,
                    ExamId = question.ExamId,
                    RightAnswer = question.RightAnswer,
                };
                _repository.Insert(question2);
                return Ok();
            }
            return BadRequest();
        }


        [HttpPut("update")]
        public ActionResult UpdateQuestion(QuestionWithExam QwE)
        {
            if (ModelState.IsValid)
            {
                var result = new Question()
                {
                    QuestionId = QwE.Id,
                    QuestionHeader = QwE.QuestionHeader,
                    QuestionFirstChoice = QwE.QuestionFirstChoice,
                    QuestionSecondChoice = QwE.QuestionSecondChoice,
                    QuestionThirdChoice = QwE.QuestionThirdChoice,
                    QuestionFourthChoice = QwE.QuestionFourthChoice,
                    RightAnswer = QwE.RightAnswer,
                    ExamId = QwE.ExamId
                };
                _repository.Update(result);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{questionId}")]
        public IActionResult GetQuestionById(int questionId)
        {
            var question = _repository.GetById(questionId);
            return question is null ? NotFound() : Ok(question);
        } 


        [HttpDelete("delete/{id}")]
        public ActionResult DeleteQuestion(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}
