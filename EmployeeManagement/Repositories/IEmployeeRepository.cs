using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {

    }

    public class EmployeeRepository : AbstractRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IIdGenerator generator) : base(generator)
        {
        }
    }
}