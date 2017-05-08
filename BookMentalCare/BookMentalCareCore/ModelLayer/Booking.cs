using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.ModelLayer
{
    public class Booking
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string description;

        public string DESCRIPTION
        {
            get { return description; }
            set { description = value; }
        }

        private string date;

        public string DATE
        {
            get { return date; }
            set { date = value; }
        }

        private string startTime;

        public string STARTTIME
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private string endTime;

        public string ENDTIME
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private Room room;

        public Room ROOM
        {
            get { return room; }
            set { room = value; }
        }

        private List<Unit> ressources;

        public List<Unit> RESSOURCES
        {
            get { return ressources; }
            set { ressources = value; }
        }

        private Patient patient;

        public Patient PATIENT
        {
            get { return patient; }
            set { patient = value; }
        }

        private List<Person> employees;

        public List<Person> EMPLOYEES
        {
            get { return employees; }
            set { employees = value; }
        }









    }
}
