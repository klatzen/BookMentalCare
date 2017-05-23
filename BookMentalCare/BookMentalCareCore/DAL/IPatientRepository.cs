using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.DAL
{
    interface IPatientRepository
    {
        bool SavePatient(Patient p);

        bool DeletePatient(int id);

        Patient FindPatient(int id);

        List<Patient> FindPatients();
        List<Patient> GetAvailablePatients(string startTime, string endTime);

    }
}
