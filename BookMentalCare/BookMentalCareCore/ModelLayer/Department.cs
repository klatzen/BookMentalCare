using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.ModelLayer
{
    public class Department
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        private string location;

        public string LOCATION
        {
            get { return location; }
            set { location = value; }
        }



    }
}
