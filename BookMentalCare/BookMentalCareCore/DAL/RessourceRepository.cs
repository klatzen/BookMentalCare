using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.DAL
{
    public class RessourceRepository : BaseRepository, IRessourceRepository
    {
        public List<Unit> LoadAllUnits(int resId)
        {
            return dbContext.Units.Where(x => x.Id == resId).ToList();
        }

        public List<Ressource> LoadAllRessources()
        {
            return dbContext.Ressources.ToList();
        }

        public Ressource LoadRessource(int id)
        {
            return dbContext.Ressources.FirstOrDefault(x => x.Id == id);
            
        }

        public Unit LoadUnit(int id)
        {
            return dbContext.Units.FirstOrDefault(x => x.Id == id);
        }

        public bool RemoveRessource(int id)
        {
            Ressource res = LoadRessource(id);
                if (res != null) {
                dbContext.Ressources.Remove(res);
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveUnit(int id)
        {
            try
            {
                Unit tempUnit = LoadUnit(id);
                if (tempUnit != null) {
                    dbContext.Units.Remove(tempUnit);
                    dbContext.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SaveRessource(Ressource ressource)
        {
            try {
                if (ressource.Id > 0)
                {
                    Ressource TempRes = LoadRessource(ressource.Id);
                    TempRes.Name = ressource.Name;
                }
                else {
                    dbContext.Ressources.Add(ressource);
                }
                dbContext.SaveChanges();
                return true;
            }
            catch {
                return false;
            }
            
        }

        public bool SaveUnit(Unit unit)
        {
            try
            {
                if(unit.Id > 0)
                {
                    Unit tempUnit = LoadUnit(unit.Id);
                    tempUnit.SerialNo = unit.SerialNo;
                }
                else
                {
                    dbContext.Units.Add(unit);
                }
                dbContext.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
    }
}
