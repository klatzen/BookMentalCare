using System;
using System.Collections.Generic;
using System.Linq;
using BookMentalCareCore.ModelLayer;
using System.Data.Entity;
using System.Data.SqlClient;

namespace BookMentalCareCore.DAL
{
    public class EmployeeRep : BaseRepository, IEmployeeRep
    {
        public bool DeleteEmployee(string initials)
        {
            try
            {
                Employee tempE = FindEmployee(initials);
                dbContext.Employees.Remove(tempE);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Employee FindEmployee(string initials)
        {
            return dbContext.Employees.FirstOrDefault(x => x.INITIALS.Equals(initials));
        }

        public List<Employee> GetEmployees()
        {
            return dbContext.Employees.Include(x => x.DEPARTMENT).ToList();
        }

        public bool SaveEmployee(Employee e)
        {
            try
            {
                if (e.ID > 0)
                {
                    Employee tempE = FindEmployee(e.INITIALS);
                    tempE.FNAME = e.FNAME;
                    tempE.LNAME = e.LNAME;
                    tempE.PASSWORD = e.PASSWORD;
                    tempE.SALT = e.SALT;
                    tempE.DEPARTMENTID = e.DEPARTMENTID;
                }else
                {
                    dbContext.Employees.Add(e);
                }


                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public List<Employee> GetAvailableEmps(string startTime, string endTime)
        {
            var s = dbContext.Employees.SqlQuery("select * from Employee e where e.ID not in (select EmployeeRefId from EmpBook eb, Booking b where eb.BookingRefId = b.ID AND b.STARTTIME between @startTime and @endTime and b.ENDTIME between @startTime and @endTime)",
                new SqlParameter("startTime", startTime),
                new SqlParameter("endTime", endTime))
                .ToList();
            return s;
        }
    }
}
