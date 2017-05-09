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

        public IEnumerable<Unit> Get(string startDate, string endDate)
        {
            return resFac.LoadAvalibleUnits(startDate, endDate);
        }

        [HttpGet]
        public Ressource GetRessource(int id)
        {
            return resFac.LoadRessource(id);
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

    }
}
