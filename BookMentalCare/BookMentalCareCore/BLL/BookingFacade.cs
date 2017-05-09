﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using BookMentalCareCore.DAL;

namespace BookMentalCareCore.BLL
{
    public class BookingFacade : IBookingFacade
    {
        private IBookingRepository bookRep;
        private IEmployeeFacade empfacade;
        private IDepartmentFacade depfacade;

        public BookingFacade()
        {
            this.bookRep = new BookingRepository();
        }

        public bool DeleteBooking(int id)
        {
            return bookRep.DeleteBooking(id);
        }

        public Booking FindBooking(int id)
        {
            return bookRep.FindBooking(id);
        }

        public List<Booking> FindBookings()
        {
            return bookRep.FindBookings();
        }

        public List<Employee> FindEmployees(string startTime, string endTime)
        {
            var depFacade = new DepartmentFacade();
            var availemps = bookRep.AvailableEmps(startTime, endTime);
            for (int i = 0; i < availemps.Count; i++)
            {
                availemps[i].DEPARTMENT = depFacade.FindDepartment(availemps[i].DEPARTMENTID);
            }
            return availemps;
            /*empfacade = new EmployeeFacade();
            var emps = empfacade.FindEmployees();
            for (int i = 0; i < emps.Count; i++)
            {
               for (int j = 0; j < availEmps.Count; j++)
                {
                    if(emps[i].ID == availEmps[j].ID)
                    {
                        emps.Remove(emps[i]);
                    }
                }
                
            }*/    

        }

        public bool SaveBooking(Booking b)
        {
            return bookRep.SaveBooking(b);
        }
    }
}
