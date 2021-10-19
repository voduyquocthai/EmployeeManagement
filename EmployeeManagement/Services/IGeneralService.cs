using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public interface IGeneralService<TModel>
    {
        IList<TModel> GetAll();
        Boolean Add(TModel model);
        TModel GetById(int id);
        void Update(TModel model);
        void Delete(int id);

    }
}
