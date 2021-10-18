using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public abstract class AbstractRepository<TModel> : IRepository<TModel> where TModel : ModelBase
    {
        protected static IList<TModel> Models = new List<TModel>();

        public TModel GetById(int id)
        {
            return Models.FirstOrDefault(i => i.Id == id);
        }

        public void Insert(TModel model)
        {
            Models.Add(model);
        }

        public void Update(TModel model)
        {
            var existingModel = Models.FirstOrDefault(i => i.Id == model.Id);

            if (existingModel != null)
            {
                var index = Models.IndexOf(existingModel);

                Models[index] = model;
            }
        }
    }
}