using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [Index(IsUnique = true)]
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
    }
}
