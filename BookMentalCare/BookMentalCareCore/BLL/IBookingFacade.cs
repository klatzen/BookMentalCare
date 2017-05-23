using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.BLL
{
    public interface IBookingFacade
    {
        bool SaveBooking(Booking b);

        bool DeleteBooking(int id);

        Booking FindBooking(int id);

        List<Booking> FindBookings();

        List<Booking> FindEmpBookings(int ID);

    }
}
