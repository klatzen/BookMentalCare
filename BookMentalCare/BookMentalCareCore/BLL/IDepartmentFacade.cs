using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.BLL
{
    public interface IDepartmentFacade
    {
        bool SaveDepartment(Department d);

        bool DeleteDepartment(int id);

        Department FindDepartment(int id);

        List<Department> FindDepartments();
    }
}
