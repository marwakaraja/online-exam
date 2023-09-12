using McqExaminationSystem.Models;

namespace McqExaminationSystem.Repositories.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly McqExaminationSystemDbContext _context;

        public QuestionRepository(McqExaminationSystemDbContext context)
        {
            _context = context;
        }
        public bool Insert(Question entity)
        {
            _context.Questions.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Question question = _context.Questions.Find(id);
            _context.Questions.Remove(question);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Question entity)
        {
            _context.Questions.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question? GetById(int id)
        {
            var result = _context.Questions.Find(id);
            _context.SaveChanges();
            return result;
        }
    }
}
