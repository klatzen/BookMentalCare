using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMentalCare.Controllers
{
    public class PatientController : ApiController
    {
        private IPatientFacade patientFac;

        public PatientController()
        {
            this.patientFac = new PatientFacade();
        }

        // GET api/<controller>
        public IEnumerable<Patient> Get()
        {
            return patientFac.FindPatients();
        }

        [Route("api/Patient/GetPatients/")]
        [HttpGet]
        public List<Patient> GetPatients(string startTime, string endTime)
        {
            return patientFac.FindAvailPatients(startTime, endTime);
        }

        // GET api/<controller>/5
        public Patient Get(int id)
        {
            return patientFac.FindPatient(id);
        }

        // POST api/<controller>
        [HttpPost, HttpPut]
        public void Post([FromBody]Patient p)
        {
            patientFac.SavePatient(p);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            patientFac.DeletePatient(id);
        }
    }
}