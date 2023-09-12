using McqExaminationSystem.Models;

namespace McqExaminationSystem.Repositories.UserExamRelationRepository
{
    public interface IUserExamRelationRepository : IRepository<UserExamRelation>
    {
        List<UserExamRelation> GetUsersWithScores(int examId);
    }
}
