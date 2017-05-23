using BookMentalCareCore.DAL;
using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.BLL
{
    public class EmployeeFacade : IEmployeeFacade
    {
        private IEmployeeRep EmpRep;
        private IDepartmentFacade depFacade;
        public EmployeeFacade()
        {
            this.EmpRep = new EmployeeRep();
        }

        public bool SaveEmployee(Employee e)
        {
            PasswordHasher pH = new PasswordHasher(e.PASSWORD);

            e.PASSWORD = pH.Hash;
            e.SALT = pH.Salt;
            e.INITIALS = GenerateInitials(e.FNAME, e.LNAME, 0);

            return EmpRep.SaveEmployee(e);
        }

        private string GenerateInitials(string fName, string lName, int count)
        {
            string initials;

            initials = fName.Substring(0, 2).ToUpper() + lName.Substring(0 + count, 2).ToUpper();

            if (FindEmployee(initials) != null)
            {
                return GenerateInitials(fName, lName, 1);
            }
            else
            {
                return initials;
            }
        }

        public bool DeleteEmplyee(string initials)
        {
            return EmpRep.DeleteEmployee(initials);
        }

        public Employee FindEmployee(string initials)
        {
            return EmpRep.FindEmployee(initials);
        }

        public List<Employee> FindEmployees()
        {
            return EmpRep.GetEmployees();
        }

        public Employee SignIn(string initials, string password)
        {
            IEmployeeFacade empFac = new EmployeeFacade();
            Employee tempEmp = empFac.FindEmployee(initials);
            Employee emp = null;

            if (tempEmp != null)
            {
                if (PasswordHasher.CheckPassword(tempEmp.SALT, tempEmp.PASSWORD, password))
                {
                    emp = tempEmp;
                }
            }


            return emp;
        }

        public List<Employee> FindAvailEmployees(string startTime, string endTime)
        {
            depFacade = new DepartmentFacade();
            var availemps = EmpRep.GetAvailableEmps(startTime, endTime);
            for (int i = 0; i < availemps.Count; i++)
            {
                availemps[i].DEPARTMENT = depFacade.FindDepartment(availemps[i].DEPARTMENTID);
            }
            return availemps;
        }
    }
}
