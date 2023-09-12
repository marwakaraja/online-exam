using McqExaminationSystem.DataTransferObjectsManagers.UserExamRelationDtosManager;
using McqExaminationSystem.dto;
using McqExaminationSystem.Models;
using McqExaminationSystem.Repositories.QuestionRepository;
using McqExaminationSystem.Repositories.UserExamRelationRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace McqExaminationSystem.Controller
{
    [Route("api/user-exam-relation")]
    [ApiController]
    public class UserExamRelationController : ControllerBase
    {
        private readonly IUserExamRelationRepository _repository;

        public UserExamRelationController(IUserExamRelationRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("insert")]
        public IActionResult Insert(UserExamRelationDTO relation)
        {
            if (ModelState.IsValid)
            {
                var UserExamRelation = new UserExamRelation
                {
                    UserId = relation.UserId,
                    ExamId = relation.ExamId,
                    ExamDateAndTime = relation.ExamDateAndTime,
                    ExamScore = relation.ExamScore,
                };
            _repository.Insert(UserExamRelation);
        }
            return Ok();
        }

        [HttpGet("users-scores/{examId}")]
        public IActionResult GetUsersScores(int examId)
        {
            var users = _repository.GetUsersWithScores(examId);
            var usersWithScoresDtos = new List<UserExamDto>();
            users.ForEach(user =>
            {
                usersWithScoresDtos.Add(new UserExamDto(
                    user.User.FullName,
                    user.ExamDateAndTime,
                    user.ExamScore));
            });
            return usersWithScoresDtos.IsNullOrEmpty() ? NotFound() : Ok(usersWithScoresDtos);
        }
    }
}
