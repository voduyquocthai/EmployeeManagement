using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.App_Data
{
    public class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }


}
