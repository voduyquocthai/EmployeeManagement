namespace EmployeeManagement.Repositories
{
    public interface IRepository<TModel>
    {
        TModel GetById(int id);
        void Insert(TModel model);
        void Update(TModel model);
    }
}