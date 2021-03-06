using System.Collections.Generic;

namespace EmployeeManagement.Repositories
{
    public interface IRepository<TModel>
    {
        IList<TModel> GetAll();
        TModel GetById(int id);
        int SearchByName(TModel model); 
        void Insert(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
    }
}