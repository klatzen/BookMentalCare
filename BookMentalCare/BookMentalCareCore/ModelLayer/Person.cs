﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.ModelLayer
{
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string fName;

        public string FNAME
        {
            get { return fName; }
            set { fName = value; }
        }

        private string lName;

        public string LNAME
        {
            get { return lName; }
            set { lName = value; }
        }

    }
}
