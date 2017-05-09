using System;
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

        public bool SaveBooking(Booking b)
        {
            return bookRep.SaveBooking(b);
        }
    }
}
