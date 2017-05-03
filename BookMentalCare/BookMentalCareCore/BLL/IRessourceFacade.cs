using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.BLL
{
    public interface IRessourceFacade
    {
        Ressource LoadRessource(int id);
        List<Ressource> LoadAllRessources();
        bool SaveRessource(Ressource ressource);
        bool RemoveRessource(int id);
    }
}
