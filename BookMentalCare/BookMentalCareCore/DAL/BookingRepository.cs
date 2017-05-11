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
                    //Skal også opdateres til at køre manuelt
                    //Booking tempB = FindBooking(b.ID);
                    //tempB.EMPLOYEES = b.EMPLOYEES;
                    //tempB.ROOM = b.ROOM;
                    //tempB.RESSOURCES = b.RESSOURCES;
                }
                else
                {
                    dbContext.Bookings.Add(b);

                    dbContext.Entry(b.PATIENT).State = EntityState.Detached;
                    dbContext.Entry(b.ROOM).State = EntityState.Detached;

                    foreach (Unit r in b.RESSOURCES)
                    {
                        dbContext.Entry(r).State = EntityState.Detached;
                    }

                    foreach (Employee e in b.EMPLOYEES)
                    {
                        dbContext.Entry(e).State = EntityState.Detached;
                    }
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
