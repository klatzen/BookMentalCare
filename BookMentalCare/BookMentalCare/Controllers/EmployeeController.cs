using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

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
        [HttpGet]
        [Route("api/employee/{initials}")]
        public Employee Get(string initials)
        {
            return empFac.FindEmployee(initials);
        }

        [Route("api/Employee/GetEmployees/")]
        [HttpGet]
        public List<Employee> GetEmps(string startTime, string endTime)
        {
            return empFac.FindAvailEmployees(startTime, endTime);
        }


        // POST api/<controller>
        [HttpPost, HttpPut]
        public void Post([FromBody]Employee e)
        {
            empFac.SaveEmployee(e);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/employee/{initials}")]
        public void Delete(string initials)
        {
            empFac.DeleteEmplyee(initials);
        }
    }
}