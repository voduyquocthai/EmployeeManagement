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

        private readonly IIdGenerator _generator;

        protected AbstractRepository(IIdGenerator generator)
        {
            _generator = generator;
        }

        public IList<TModel> GetAll()
        {
            return Models;
        }

        public TModel GetById(int id)
        {
            return Models.FirstOrDefault(i => i.Id == id);
        }

        public int SearchByName(string name)
        {
            var searchModel = Models.FirstOrDefault(i => i.Name == name);
            return searchModel?.Id ?? 0;
        }

        public void Insert(TModel model)
        {
            model.Id = _generator.GenId();
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