using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using BookMentalCareCore.DAL;

namespace BookMentalCareCore.BLL
{
    public class PatientFacade : IPatientFacade
    {
        private IPatientRepository patientRep;

        public PatientFacade()
        {
            this.patientRep = new PatientRepository();
        }

        public bool DeletePatient(int id)
        {
            return patientRep.DeletePatient(id);
        }

        public Patient FindPatient(int id)
        {
            return patientRep.FindPatient(id);
        }

        public List<Patient> FindPatients()
        {
            return patientRep.FindPatients();
        }

        public bool SavePatient(Patient p)
        {
            return patientRep.SavePatient(p);
        }
    }
}
