using McqExaminationSystem.Models;

namespace McqExaminationSystem.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetByCredentials(string username, string password);
    }
}
