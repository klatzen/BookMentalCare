﻿using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMentalCare.Controllers
{
    public class BookingController : ApiController
    {
        private IBookingFacade bookFac;

        public BookingController()
        {
            this.bookFac = new BookingFacade();
        }

        // GET api/<controller>
        public IEnumerable<Booking> Get()
        {
            return bookFac.FindBookings();
        }

        // GET api/<controller>/5
        public Booking Get(int id)
        {
            return bookFac.FindBooking(id);
        }

        // POST api/<controller>
        [HttpPost, HttpPut]
        public void Post([FromBody]Booking b)
        {
            b.DATE = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            bookFac.SaveBooking(b);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            bookFac.DeleteBooking(id);
        }

        [Route("api/booking/getEmpBooking/{id}")]
        [HttpGet]
        public List<Booking> GetEmpBookings(int id)
        {
            return bookFac.FindEmpBookings(id);
        }
    }
}