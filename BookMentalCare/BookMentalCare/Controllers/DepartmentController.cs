using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace BookMentalCare.Controllers
{
    public class DepartmentController : ApiController
    {

        private IDepartmentFacade depFac;

        public DepartmentController()
        {
            this.depFac = new DepartmentFacade();
        }


        // GET api/<controller>
        public IEnumerable<Department> Get()
        {
            return depFac.FindDepartments();
        }

        // GET api/<controller>/5
        public Department Get(int id)
        {
            return depFac.FindDepartment(id);
        }

        // POST api/<controller>
        [HttpPost, HttpPut]
        public void Post([FromBody]Department d)
        {
            depFac.SaveDepartment(d);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            depFac.DeleteDepartment(id);
        }
    }
}