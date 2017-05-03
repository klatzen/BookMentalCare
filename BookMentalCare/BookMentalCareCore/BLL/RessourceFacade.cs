using BookMentalCareCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.BLL
{

    //lile ændring
    public class RessourceFacade : IRessourceFacade
    {
        private IRessourceRepository resRep;

        public RessourceFacade()
        {
            resRep = new RessourceRepository();
        }

        public List<Ressource> LoadAllRessources()
        {
            return resRep.LoadAllRessources();
        }

        public Ressource LoadRessource(int id)
        {
            return resRep.LoadRessource(id);
        }

        public bool RemoveRessource(int id)
        {
            Ressource res = LoadRessource(id);
            if (res.units == null)
            {
                resRep.RemoveRessource(id);
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool SaveRessource(Ressource ressource)
        {
            return resRep.SaveRessource(ressource);
        }
    }
}
