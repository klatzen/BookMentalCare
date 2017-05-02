using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.DAL
{
    public interface IEmployeeRep
    {
        bool SaveEmployee(Employee e);

        bool DeleteEmployee(Employee e);

        Employee FindEmployee(string initials);

        List<Employee> GetEmployees();
    }
}
