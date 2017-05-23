using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;
using System.Web.Http;

namespace BookMentalCare.Controllers
{
    public class UnitController : ApiController
    {
        private IRessourceFacade resFac;

        public UnitController()
        {
            this.resFac = new RessourceFacade();
        }

        [Route("api/unit/units/{id}")]
        [HttpGet]
        public IEnumerable<Unit> GetUnits(int id)
        {
            return resFac.LoadAllUnits(id);
        }

        [Route("api/unit/unit/{id}")]
        [HttpGet]
        public Unit GetUnit(int id)
        {
            return resFac.LoadUnit(id);
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
