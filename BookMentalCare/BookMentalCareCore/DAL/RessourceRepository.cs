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
        public List<Ressource> LoadAllRessources()
        {
            throw new NotImplementedException();
        }

        public Ressource LoadRessource(int id)
        {
            return dbContext.Ressources.FirstOrDefault(x => x.Id == id);
            
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

        public bool SaveRessource(Ressource ressource)
        {
            if (ressource.Id > 0)
            {
                Ressource TempRes = LoadRessource(ressource.Id);
                TempRes.Name = ressource.Name;
            }
            else {
                dbContext.Ressources.Add(ressource);
            }
           return  dbContext.saveChanges();
        }
    }
}
