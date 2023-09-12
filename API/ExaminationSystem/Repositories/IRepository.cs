namespace McqExaminationSystem.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
