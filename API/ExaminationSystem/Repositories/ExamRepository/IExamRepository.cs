using McqExaminationSystem.Models;

namespace McqExaminationSystem.Repositories.ExamRepository
{
    public interface IExamRepository : IRepository<Exam>
    {
        List<Exam> GetAll();
        ICollection<Question> GetQuestionsByExamId(int id);
        Exam GetById(int examId);
        // List<User> GetUsersWithScoresByExamId(int examId);
    }
}
