using BookMentalCareCore.DAL;
using System.Collections.Generic;
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

        public List<Unit> LoadAllUnits(int resId)
        {
            return resRep.LoadAllUnits(resId);
        }

        public List<Ressource> LoadAvalibleUnits(string startDate, string endDate)
        {
            List<Unit> avalUnits = resRep.LoadAllAvalibleUnits(startDate, endDate);
            List<Ressource> avalRes = new List<Ressource>();

            foreach (Unit u in avalUnits)
            {

                Ressource aRes = avalRes.Find(x => x.Id == u.RessourceId);

                if (aRes == null)
                {
                    Ressource tempR = LoadRessource(u.RessourceId);
                    tempR.units = new List<Unit>();
                    tempR.units.Add(u);
                    avalRes.Add(tempR);
                }
                else
                {
                    aRes.units.Add(u);
                }
            }

            return avalRes;
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
