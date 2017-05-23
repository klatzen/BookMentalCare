using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BookMentalCareCore.ModelLayer;

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
            RessourceRepository resRepo = new RessourceRepository();
            DepartmentRepository depRepo = new DepartmentRepository();
            Booking b = dbContext.Bookings.Include(x => x.EMPLOYEES).Include(x => x.RESSOURCES).Include(x => x.ROOM).Include(x => x.PATIENT).FirstOrDefault(x => x.ID == id);
            foreach (Unit item in b.RESSOURCES)
            {
                item.Ressource = resRepo.LoadRessource(item.RessourceId);
            }
            foreach (Employee e in b.EMPLOYEES)
            {
                e.DEPARTMENT = depRepo.FindDepartment(e.DEPARTMENTID);
            }
            return b;
        }
        public List<Booking> FindEmpBookings(int ID)
        {
            List<Booking> bookings = new List<Booking>();
            var list = dbContext.Database.SqlQuery<int>("select BookingRefId from EmpBook where EmployeeRefId = @p0", ID).ToList();

            foreach (var item in list)
            {
                bookings.Add(FindBooking(item));
            }
            return bookings;
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
                b.PATIENTID = b.PATIENT.ID;
                b.PATIENT = null;
                b.ROOMID = b.ROOM.ID;
                b.ROOM = null;

                b.EMPLOYEES = null;
                b.RESSOURCES = null;
                if (b.ID > 0)
                {
                    deleteResAndEmp(b.ID);

                    Booking tempB = FindBooking(b.ID);
                    tempB.DESCRIPTION = b.DESCRIPTION;

                }
                else
                {

                    dbContext.Bookings.Add(b);

                }
                dbContext.SaveChanges();
                return insertEmpsAndRes(b.ID, tempEmps, tempRes);

            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool deleteResAndEmp(int ID)
        {
            try
            {
                dbContext.Database.ExecuteSqlCommand("delete from UnitBook where BookingRefId = @p0", ID);
                dbContext.Database.ExecuteSqlCommand("delete from EmpBook where BookingRefId = @p0", ID);
                dbContext.SaveChanges();
                return true;
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
                foreach (Employee e in emps)
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
