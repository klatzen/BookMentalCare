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
    public class UnitController : ApiController
    {
        private IRessourceFacade resFac;

        public UnitController() {

            this.resFac = new RessourceFacade();
        }

        [Route("api/unit/units/{Id}")]
        [HttpGet]
        public IEnumerable<Unit> GetUnits(int Id)
        {
            return resFac.LoadAllUnits(Id);
        }

        [Route("api/unit/unit/{Id}")]
        [HttpGet]
        public Unit GetUnit(int Id)
        {
            return resFac.LoadUnit(Id);
        }

       
        [HttpPost, HttpPut]
        public void PostUnit([FromBody]Unit unit)
        {
            resFac.SaveUnit(unit);
        }


        [HttpDelete]
        public void DeleteUnit(int id)
        {
            resFac.RemoveUnit(id);
        }
    }
}
