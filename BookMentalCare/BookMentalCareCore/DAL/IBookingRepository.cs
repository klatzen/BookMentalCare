using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.DAL
{
    public interface IBookingRepository
    {
        bool SaveBooking(Booking b);

        bool DeleteBooking(int id);

        Booking FindBooking(int id);

        List<Booking> FindBookings();

        List<Booking> FindEmpBookings(int ID);
    }
}
