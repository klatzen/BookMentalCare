using BookMentalCareCore.DAL;
using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.BLL
{
    public class EmployeeFacade : IEmployeeFacade
    {
        private IEmployeeRep EmpRep;
        public EmployeeFacade()
        {
            this.EmpRep = new EmployeeRep();
        }

        public bool SaveEmployee(Employee e)
        {
            PasswordHasher pH = new PasswordHasher(e.PASSWORD);

            e.PASSWORD = pH.Hash;
            e.SALT = pH.Salt;

            return EmpRep.SaveEmployee(e);
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

    }
}
