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
            throw new NotImplementedException();
        }

        public Ressource SaveRessource(Ressource ressource)
        {
            throw new NotImplementedException();
        }
    }
}
