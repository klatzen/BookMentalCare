using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using BookMentalCareCore.DAL;

namespace BookMentalCareCore.BLL
{
    public class DepartmentFacade : IDepartmentFacade
    {

        private IDepartmentRepository depRep;

        public DepartmentFacade()
        {
            this.depRep = new DepartmentRepository();
        }

        public bool DeleteDepartment(int id)
        {
            return depRep.DeleteDepartment(id);
        }

        public Department FindDepartment(int id)
        {
            return depRep.FindDepartment(id);
        }

        public List<Department> FindDepartments()
        {
            return depRep.FindDepartments();
        }

        public bool SaveDepartment(Department d)
        {
            return depRep.SaveDepartment(d);
        }
    }
}
