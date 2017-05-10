using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
