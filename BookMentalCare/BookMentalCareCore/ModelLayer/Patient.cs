using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.ModelLayer
{
    public class Patient : Person
    {
        private string medRegNo;

        public string MEDREGNO
        {
            get { return medRegNo; }
            set { medRegNo = value; }
        }
    }
}
