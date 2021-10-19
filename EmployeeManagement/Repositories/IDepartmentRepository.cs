using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {

    }

    public class DepartmentRepository : AbstractRepository<Department>, IDepartmentRepository
    {

    }
}
