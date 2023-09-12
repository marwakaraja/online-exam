using McqExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace McqExaminationSystem.Repositories.UserExamRelationRepository
{
    public class UserExamRelationRepository : IUserExamRelationRepository
    {
        private readonly McqExaminationSystemDbContext _context;

        public UserExamRelationRepository(McqExaminationSystemDbContext context)
        {
            _context = context;
        }

        public List<UserExamRelation> GetUsersWithScores(int examId)
        {
            return _context.UserExamRelations.Where(exam => exam.ExamId == examId)
                .Include(exam => exam.User)
                .AsNoTracking()
                .ToList();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserExamRelation> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserExamRelation? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(UserExamRelation entity)
        {
            _context.UserExamRelations.Add(entity);
            _context.SaveChanges();
            return true;
        }

        public bool Update(UserExamRelation entity)
        {
            throw new NotImplementedException();
        }
    }
}
