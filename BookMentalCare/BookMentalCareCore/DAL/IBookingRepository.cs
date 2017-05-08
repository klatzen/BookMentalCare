using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.DAL
{
    public interface IBookingRepository
    {
        bool SaveBooking(Booking b);

        bool DeleteBooking(int id);

        Booking FindBooking(int id);

        List<Booking> FindBookings();
    }
}
