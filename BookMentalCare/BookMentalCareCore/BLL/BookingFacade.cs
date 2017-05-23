using System.Collections.Generic;
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

        public List<Booking> FindEmpBookings(int ID)
        {
            return bookRep.FindEmpBookings(ID);
        }

        public bool SaveBooking(Booking b)
        {
            return bookRep.SaveBooking(b);
        }
    }
}
