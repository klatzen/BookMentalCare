using System.Collections.Generic;
using System.Linq;
using BookMentalCareCore.ModelLayer;

namespace BookMentalCareCore.DAL
{
    public class RessourceRepository : BaseRepository, IRessourceRepository
    {
        public List<Unit> LoadAllAvalibleUnits(string startDate, string endDate)
        {
            return dbContext.Units.SqlQuery("select * from Unit where id not in (select UnitRefId from UnitBook ub, booking b where ub.BookingRefId = b.ID AND b.STARTTIME between @p0 and @p1 And b.ENDTIME between @p0 and @p1)", startDate, endDate).ToList();
        }

        public List<Ressource> LoadAllRessources()
        {
            return dbContext.Ressources.ToList();
        }

        public List<Unit> LoadAllUnits(int resId)
        {
            return dbContext.Units.Where(x => x.RessourceId == resId).ToList();
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
            if (res != null)
            {
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
                if (tempUnit != null)
                {
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
            try
            {
                if (ressource.Id > 0)
                {
                    Ressource TempRes = LoadRessource(ressource.Id);
                    TempRes.Name = ressource.Name;
                    TempRes.units = null;
                }
                else
                {
                    dbContext.Ressources.Add(ressource);
                }
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool SaveUnit(Unit unit)
        {
            try
            {
                if (unit.Id > 0)
                {
                    Unit tempUnit = LoadUnit(unit.Id);
                    tempUnit.SerialNo = unit.SerialNo;
                    tempUnit.Ressource = null;
                }
                else
                {
                    unit.RessourceId = unit.Ressource.Id;
                    unit.Ressource = null;
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
