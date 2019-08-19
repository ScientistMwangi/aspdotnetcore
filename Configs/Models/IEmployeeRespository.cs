using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Configs.Models
{
    public interface IEmployeeRespository
    {
        Employees GetEmployees(int id);
        IEnumerable<Employees> GetAllEmployees();

        Employees Create(Employees emp);

        Employees Update(Employees employee);
        Employees Delete(int id);
    }
}
