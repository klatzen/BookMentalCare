using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using System.Data.Entity;
using System.Data.SqlClient;

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
            return dbContext.Patients.Include(x=> x.DEPARTMENT).FirstOrDefault(x => x.ID == id);
        }

        public List<Patient> FindPatients()
        {
            return dbContext.Patients.Include(x=>x.DEPARTMENT).ToList();
        }

        public List<Patient> GetAvailablePatients(string startTime, string endTime)
        {
            var s = dbContext.Patients.SqlQuery("select * from Patient p where p.ID not in (select PATIENTID from Booking b where b.STARTTIME between @startTime and @endTime and b.ENDTIME between @startTime and @endTime)",
                new SqlParameter("startTime", startTime),
                new SqlParameter("endTime", endTime))
                .ToList();
            return s;
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
                    tempP.DEPARTMENT = null;
                }
                else
                {
                    p.DEPARTMENTID = p.DEPARTMENT.ID;
                    p.DEPARTMENT = null;
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
