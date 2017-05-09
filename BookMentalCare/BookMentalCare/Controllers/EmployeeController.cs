using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BookMentalCare.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeFacade empFac;
        public EmployeeController()
        {
            this.empFac = new EmployeeFacade();
        }

        [Route("api/employee/signIn")]
        [HttpGet]
        public Employee SignIn()
        {
            return empFac.SignIn(Request.Headers.GetValues("Initials").FirstOrDefault(), Request.Headers.GetValues("Password").FirstOrDefault());
        }

        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return empFac.FindEmployees();
        }

        // GET api/<controller>/5
        public Employee Get(string id)
        {
            return empFac.FindEmployee(id);
        }

        // POST api/<controller>
        [HttpPost, HttpPut]
        public void Post([FromBody]Employee e)
        {
            e.DEPARTMENTID = e.DEPARTMENT.ID;
            e.DEPARTMENT = null;
            empFac.SaveEmployee(e);
        }

        // DELETE api/<controller>/5
        public void Delete(string initials)
        {
            empFac.DeleteEmplyee(initials);
        }
    }
}