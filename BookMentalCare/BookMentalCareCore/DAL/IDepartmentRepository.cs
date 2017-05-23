using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.DAL
{
    public interface IDepartmentRepository
    {

        bool SaveDepartment(Department d);

        bool DeleteDepartment(int id);

        Department FindDepartment(int id);

        List<Department> FindDepartments();


    }
}
