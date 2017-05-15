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
                List<Employee> tempEmps = b.EMPLOYEES;
                List<Unit> tempRes = b.RESSOURCES;
                if (b.ID > 0)
                {
                    //Skal også opdateres til at køre manuelt
                    //Booking tempB = FindBooking(b.ID);
                    //tempB.EMPLOYEES = b.EMPLOYEES;
                    //tempB.ROOM = b.ROOM;
                    //tempB.RESSOURCES = b.RESSOURCES;
                }
                else
                {

                    b.PATIENTID = b.PATIENT.ID;
                    b.PATIENT = null;
                    b.ROOMID = b.ROOM.ID;
                    b.ROOM = null;

                    b.EMPLOYEES = null;
                    b.RESSOURCES = null;


                    dbContext.Bookings.Add(b);
                }

                dbContext.SaveChanges();

                int id = b.ID;

                return insertEmpsAndRes(id, tempEmps, tempRes);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool insertEmpsAndRes(int bookingID, List<Employee> emps, List<Unit> res)
        {
            try
            {
                foreach(Employee e in emps)
                {
                    dbContext.Database.ExecuteSqlCommand("insert into EmpBook values(@p0, @p1)", e.ID, bookingID);
                }
                foreach (Unit u in res)
                {
                    dbContext.Database.ExecuteSqlCommand("insert into UnitBook values(@p0, @p1)", u.Id, bookingID);
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
