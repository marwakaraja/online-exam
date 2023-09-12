using McqExaminationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace McqExaminationSystem.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly McqExaminationSystemDbContext dbContext;

        public UserRepository(McqExaminationSystemDbContext dbContext) => this.dbContext = dbContext;

        public List<User> GetAll()
        {
            return dbContext
                .Users
                .Where(user => user.IsDeleted == false)
                .ToList();
        }

        public User? GetById(int userId)
        {
            return dbContext
                .Users
                .FirstOrDefault(user =>
                    user.UserId == userId &&
                    user.IsDeleted == false);
        }

        public User? GetByCredentials(string username, string password)
        {
            return dbContext
                .Users
                .FirstOrDefault(user => 
                    user.UserName == username &&
                    user.Password == password &&
                    user.IsDeleted == false);
        }

        public bool Insert(User user)
        {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(User user)
        {
            try
            {
                dbContext.Users.Update(user);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int userId)
        {
            try
            {
                var user = GetById(userId);
                if (user != null)
                {
                    user.IsDeleted = true;
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
    }
}
