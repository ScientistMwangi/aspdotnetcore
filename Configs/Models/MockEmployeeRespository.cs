using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configs.Models
{
    public class MockEmployeeRespository:IEmployeeRespository
    {
        private List<Employees> _employees;

        public MockEmployeeRespository()
        {
            _employees = new List<Employees>() {

                                new Employees { Id=1,Name="Mwangi",Email="mwangi@gmail.com",Department=Dept.IT},
                                new Employees { Id = 2, Name = "Maureen", Email = "maureen@gmail.com", Department = Dept.HR},
                                new Employees { Id=3,Name="Makori",Email="makori@gmail.com",Department=Dept.none},
                                new Employees { Id = 4, Name = "Ben", Email = "ben@gmail.com", Department = Dept.Marketing}
            };
                


                
        }

        public Employees Create(Employees emp)
        {
            emp.Id = _employees.Max(x=>x.Id)+1;
            _employees.Add(emp);

            return emp;
            
        }

        public Employees Delete(int id)
        {
            Employees emp = _employees.Find(x =>x.Id==id);
            if (emp != null)
            {
                _employees.Remove(emp);
            }

            return emp;
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            return _employees;
        }

        public Employees GetEmployees(int id)
        {
            return _employees.FirstOrDefault(x=>x.Id==id);
        }

        public Employees Update(Employees employee)
        {
            var updateEmp = _employees.Find(x=>x.Id==employee.Id);
            if(updateEmp != null)
            {
                updateEmp.Name = employee.Name;
                updateEmp.Email = employee.Email;
                updateEmp.Department = employee.Department;
            }
            return updateEmp;
            
        }
    }
}
