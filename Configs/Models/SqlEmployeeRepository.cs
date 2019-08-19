using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configs.Models
{
    public class SqlEmployeeRepository : IEmployeeRespository
    {
        private readonly AppDBContext _dbContext;
        public SqlEmployeeRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Employees Create(Employees emp)
        {
            _dbContext.DbSetEmployees.Add(emp);
            _dbContext.SaveChanges();

            return emp;

        }

        public Employees Delete(int id)
        {
            Employees emp = _dbContext.DbSetEmployees.Find(id);
            if(emp != null)
            {
                _dbContext.DbSetEmployees.Remove(emp);
                _dbContext.SaveChanges();
            }

            return emp;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return _dbContext.DbSetEmployees;
        }

        public Employees GetEmployees(int id)
        {
           return _dbContext.DbSetEmployees.Find(id);
        }

        public Employees Update(Employees employeeChanges)
        {
            var employee = _dbContext.DbSetEmployees.Attach(employeeChanges);//attach changes
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;//modify it's state
            _dbContext.SaveChanges();

            return employeeChanges;

        }
    }
}
