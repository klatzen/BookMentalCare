using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.DAL
{
    public interface IRessourceRepository
    {
        Ressource LoadRessource(int id);
        List<Ressource> LoadAllRessources();
        Ressource SaveRessource(Ressource ressource);
        bool RemoveRessource(int id);

    }
}
