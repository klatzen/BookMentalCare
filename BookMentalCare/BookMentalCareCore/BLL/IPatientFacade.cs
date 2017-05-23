using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.BLL
{
    public interface IPatientFacade
    {

        bool SavePatient(Patient p);

        bool DeletePatient(int id);

        Patient FindPatient(int id);
        List<Patient> FindPatients();
        List<Patient> FindAvailPatients(string startTime, string endTime);

    }
}
