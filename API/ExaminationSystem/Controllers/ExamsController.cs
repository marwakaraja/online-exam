using McqExaminationSystem.Controller;
using McqExaminationSystem.DataTransferObjectsManagers.ExamDtosManager;
using McqExaminationSystem.DataTransferObjectsManagers.ExamDtosManager.ExamDtos;
using McqExaminationSystem.dto;
using McqExaminationSystem.Models;
using McqExaminationSystem.Repositories.ExamRepository;
using McqExaminationSystem.Repositories.QuestionRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace McqExaminationSystem.Controller
{
    [Route("api/exam")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _repository;
        private readonly IExamDtosManager examDtosManager;

        public ExamsController(IExamRepository repository, IExamDtosManager examDtosManager)
        {
            _repository = repository;
            this.examDtosManager = examDtosManager;
        }

        [HttpGet("all")]
        public ActionResult GetAll() {
           var x= _repository.GetAll();
            return Ok(x);
        }
        [HttpGet("exam-questions/{examId}")]
        public ActionResult GetQuestions(int examId)
        {
            var y = _repository.GetQuestionsByExamId(examId).Select(x => new examQuestionsdto
            {
                ExamId = x.ExamId,
                QuestionId = x.QuestionId,
                QuestionHeader = x.QuestionHeader,
                QuestionFirstChoice = x.QuestionFirstChoice,
                QuestionSecondChoice = x.QuestionSecondChoice,
                QuestionThirdChoice = x.QuestionThirdChoice,
                QuestionFourthChoice = x.QuestionFourthChoice,
                RightAnswer = x.RightAnswer,
            });
            return Ok(y);
        }
            [HttpGet("{examId}")]
            public ActionResult GetExam(int examId)
            {
            var y = _repository.GetById(examId);
               
                return Ok(y);
            }

        [HttpPost("insert")]
        public IActionResult Insert(ExamDto examDto)
        {
            return examDtosManager.InsertEntityUsingDto(examDto) ?
                Ok("Successful Insertion!")
                : BadRequest();
        }

        [HttpPut("update")]
        public IActionResult Update(ExamDto examDto)
        {
            return examDtosManager.UpdateEntityUsingDto(examDto) ?
                Ok("Successful Update!")
                : BadRequest();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int examId)
        {
            return examDtosManager.DeleteEntity(examId) ?
                Ok("Successful Deletion!")
                : BadRequest();
        }
    }
}
