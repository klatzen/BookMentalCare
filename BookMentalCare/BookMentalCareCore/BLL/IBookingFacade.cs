﻿using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.BLL
{
    public interface IBookingFacade
    {
        bool SaveBooking(Booking b);

        bool DeleteBooking(int id);

        Booking FindBooking(int id);

        List<Booking> FindBookings();

        List<Employee> FindEmployees(string startTime, string endTime);
    }
}
