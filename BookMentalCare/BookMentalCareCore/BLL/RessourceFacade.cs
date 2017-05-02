using BookMentalCareCore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.BLL
{
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

        public List<Unit> LoadAllUnits(int resId)
        {
            return resRep.LoadAllUnits(resId);
        }

        public Ressource LoadRessource(int id)
        {
            return resRep.LoadRessource(id);
        }

        public Unit LoadUnit(int id)
        {
            return resRep.LoadUnit(id);
        }

        public bool RemoveRessource(int id)
        {
            Ressource res = LoadRessource(id);
            if(res.units == null)
            {
                resRep.RemoveRessource(id);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveUnit(int id)
        {
            return resRep.RemoveUnit(id);
        }

        public bool SaveRessource(Ressource ressource)
        {
            return resRep.SaveRessource(ressource);
        }

        public bool SaveUnit(Unit unit)
        {
            return resRep.SaveUnit(unit);
        }
    }
    }

