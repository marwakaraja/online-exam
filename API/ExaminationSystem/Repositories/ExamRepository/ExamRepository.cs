using McqExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace McqExaminationSystem.Repositories.ExamRepository
{
    public class ExamRepository : IExamRepository
    {
        private readonly McqExaminationSystemDbContext dbContext;

        public ExamRepository(McqExaminationSystemDbContext dbContext) => this.dbContext = dbContext;

        public Exam? GetById(int examId)
        {
            return dbContext
                .Exams
                .FirstOrDefault(exam =>
                    exam.ExamId == examId &&
                    exam.IsDeleted == false);
        }

        public bool Insert(Exam exam)
        {
            try
            {
                dbContext.Exams.Add(exam);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Exam exam)
        {
            try
            {
                dbContext.Exams.Update(exam);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int examId)
        {
            try
            {
                var exam = GetById(examId);
                if (exam != null)
                {
                    exam.IsDeleted = true;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<Exam> GetAll()
        {
            List<Exam> exams = dbContext.Exams.Where(exam => exam.IsDeleted == false).ToList();
            return exams;
        }

        public ICollection<Question> GetQuestionsByExamId(int id)
        {
            var exam = dbContext.Exams.Include(e => e.Questions).FirstOrDefault(e => e.ExamId == id);
            return exam.Questions;
        }

       
    }
}
