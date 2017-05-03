﻿using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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


        // GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return empFac.FindEmployees();
        }

        // GET api/<controller>/5
        [Route("Employee/{id}")]
        public Employee Get(string id)
        {
            return empFac.FindEmployee(id);
        }

        // POST api/<controller>
        [HttpPost, HttpPut]
        public void Post([FromBody]Employee e)
        {
            empFac.SaveEmployee(e);
        }

        // DELETE api/<controller>/5
        [Route("Employee/{initials}")]
        public void Delete(string initials)
        {
            empFac.DeleteEmplyee(initials);
        }
    }
}