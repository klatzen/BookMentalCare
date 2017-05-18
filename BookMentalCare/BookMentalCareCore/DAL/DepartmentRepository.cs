using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.DAL
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public bool DeleteDepartment(int id)
        {
            try
            {
                Department tempDep = FindDepartment(id);

                dbContext.Departments.Remove(tempDep);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Department FindDepartment(int id)
        {
            return dbContext.Departments.FirstOrDefault(x => x.ID == id);
        }

        public List<Department> FindDepartments()
        {
            return dbContext.Departments.ToList();
        }

        public bool SaveDepartment(Department d)
        {
            try
            {
                if(d.ID > 0)
                {
                    Department tempDep = FindDepartment(d.ID);
                    tempDep.LOCATION = d.LOCATION;
                    tempDep.NAME = d.NAME;
                }else
                {
                    dbContext.Departments.Add(d);
                }
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
