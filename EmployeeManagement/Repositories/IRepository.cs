using System;
using System.Collections.Generic;

namespace EmployeeManagement.Repositories
{
    public interface IRepository<TModel>
    {
        IList<TModel> GetAll();
        TModel GetById(int id);
        int SearchByName(string name); 
        void Insert(TModel model);
        void Delete(TModel model);
    }
}