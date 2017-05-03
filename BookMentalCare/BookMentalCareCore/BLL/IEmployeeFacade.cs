using System.Collections.Generic;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.BLL
{
    public interface IEmployeeFacade
    {
        bool DeleteEmplyee(string initials);
        Employee FindEmployee(string initials);
        List<Employee> FindEmployees();
        bool SaveEmployee(Employee e);
    }
}