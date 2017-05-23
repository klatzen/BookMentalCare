using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.DAL
{
    public interface IEmployeeRep
    {
        bool SaveEmployee(Employee e);

        bool DeleteEmployee(string initials);

        Employee FindEmployee(string initials);

        List<Employee> GetEmployees();

        List<Employee> GetAvailableEmps(string startTime, string endTime);
    }
}
