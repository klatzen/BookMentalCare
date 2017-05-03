using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.DAL
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public bool DeletePatient(int id)
        {
            try
            {
                Patient tempP = FindPatient(id);

                dbContext.Patients.Remove(tempP);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Patient FindPatient(int id)
        {
            return dbContext.Patients.FirstOrDefault(x => x.ID == id);
        }

        public List<Patient> FindPatients()
        {
            return dbContext.Patients.ToList();
        }

        public bool SavePatient(Patient p)
        {
            try
            {
                if (p.ID > 0)
                {
                    Patient tempP = FindPatient(p.ID);
                    tempP.FNAME = p.FNAME;
                    tempP.LNAME = p.LNAME;
                    tempP.MEDREGNO = p.MEDREGNO;
                }
                else
                {
                    dbContext.Patients.Add(p);
                }
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
