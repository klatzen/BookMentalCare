using System.Collections.Generic;
using BookMentalCareCore.ModelLayer;
using BookMentalCareCore.DAL;

namespace BookMentalCareCore.BLL
{
    public class PatientFacade : IPatientFacade
    {
        private IPatientRepository patientRep;
        private IDepartmentFacade depFacade;

        public PatientFacade()
        {
            this.patientRep = new PatientRepository();
        }

        public bool DeletePatient(int id)
        {
            return patientRep.DeletePatient(id);
        }

        public List<Patient> FindAvailPatients(string startTime, string endTime)
        {
            depFacade = new DepartmentFacade();
            var availPatients = patientRep.GetAvailablePatients(startTime, endTime);
            for (int i = 0; i < availPatients.Count; i++)
            {
                availPatients[i].DEPARTMENT = depFacade.FindDepartment(availPatients[i].DEPARTMENTID);
            }
            return availPatients;
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
