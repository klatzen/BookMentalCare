using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
