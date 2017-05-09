using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using System.Data.SqlClient;

namespace BookMentalCareCore.DAL
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {
        public bool DeleteBooking(int id)
        {
            try
            {
                dbContext.Bookings.Remove(FindBooking(id));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Booking FindBooking(int id)
        {
            return dbContext.Bookings.Include(x => x.EMPLOYEES).Include(x => x.RESSOURCES).Include(x => x.ROOM).Include(x => x.PATIENT).FirstOrDefault(x => x.ID == id);
        }

        public List<Booking> FindBookings()
        {
            return dbContext.Bookings.ToList();
        }

        public bool SaveBooking(Booking b)
        {
            try
            {
                if (b.ID > 0)
                {
                    Booking tempB = FindBooking(b.ID);
                    tempB.EMPLOYEES = b.EMPLOYEES;
                    tempB.ROOM = b.ROOM;
                    tempB.RESSOURCES = b.RESSOURCES;
                }
                else
                {
                    dbContext.Bookings.Add(b);
                }

                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Employee> AvailableEmps(string startTime, string endTime)
        {

            var s = dbContext.Employees.SqlQuery("select * from Employee where id not in (select EmployeeRefId from EmpBook eb, Booking b where eb.BookingRefId = b.ID AND b.STARTTIME between @startTime and @endTime and b.ENDTIME between @startTime and @endTime)",
                new SqlParameter("startTime",startTime),
                new SqlParameter("endTime",endTime)).ToList();
            return s;
            /*return dbContext.Bookings.Include(e => e.EMPLOYEES).Where(x => Convert.ToDateTime(x.STARTTIME) < Convert.ToDateTime(endTime) 
            && Convert.ToDateTime(x.ENDTIME) > Convert.ToDateTime(startTime)).Select(e => e.EMPLOYEES).ToList()[0];*/
            

        }
    }
}
