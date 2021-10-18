using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public abstract class AbstractRepository<TModel> : IRepository<TModel> where TModel : ModelBase
    {
        protected static IList<TModel> Models = new List<TModel>();

        public static int counter = 1;

        public IList<TModel> GetAll()
        {
            return Models;
        }

        public TModel GetById(int id)
        {
            return Models.FirstOrDefault(i => i.Id == id);
        }

        public int SearchByName(TModel model)
        {
            var searchModel = Models.FirstOrDefault(i => i.Name == model.Name);
            return searchModel != null ? searchModel.Id : 0;
        }

        public void Insert(TModel model)
        {
            model.Id = counter;
            counter++;
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

        public void Delete(TModel model)
        {
            Models.Remove(model);
        }
    }
}