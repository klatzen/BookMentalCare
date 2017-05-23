﻿using System.Collections.Generic;

namespace BookMentalCareCore.ModelLayer
{
    public class Employee : Person
    {
        private string title;

        public string TITLE
        {
            get { return title; }
            set { title = value; }
        }

        private string initials;

        public string INITIALS
        {
            get { return initials; }
            set { initials = value; }
        }

        private string password;

        public string PASSWORD
        {
            get { return password; }
            set { password = value; }
        }

        private string salt;

        public string SALT
        {
            get { return salt; }
            set { salt = value; }
        }

        private List<Booking> bookings;

        public List<Booking> BOOKINGS
        {
            get { return bookings; }
            set { bookings = value; }
        }

    }
}
