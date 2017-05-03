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
    public class RessourceController : ApiController
    {
        private IRessourceFacade resFac;

        public RessourceController()
        {
            this.resFac = new RessourceFacade();
        }

       
        public IEnumerable<Ressource> Get()
        {
            return resFac.LoadAllRessources();
        }

        
        public Ressource Get(int id)
        {
            return resFac.LoadRessource(id);
        }

        
        [Route ("Ressource/units")]
        [HttpGet]
        public IEnumerable<Unit> GetUnits(int resId)
        {
            return resFac.LoadAllUnits(resId);
        }

        [Route("Ressource/unit")]
        [HttpGet]
        public Unit GetUnit(int id)
        {
            return resFac.LoadUnit(id);
        }

        [Route("Ressource/unit")]
        [HttpPost,HttpPut]
        public void PostUnit([FromBody]Unit unit)
        {
            resFac.SaveUnit(unit);
        }

        [HttpPost,HttpPut]
        public void Post([FromBody]Ressource res)
        {
            resFac.SaveRessource(res);
        }

        
        public void Delete(int id)
        {
            resFac.RemoveRessource(id);
        }

        [Route("Ressource/unit")]
        [HttpDelete]
        public void DeleteUnit(int id)
        {
            resFac.RemoveUnit(id);
        }
    }
}
