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
        bool SaveRessource(Ressource ressource);
        bool RemoveRessource(int id);
        Unit LoadUnit(int id);
        List<Unit> LoadAllUnits(int resId);
        bool RemoveUnit(int id);
        bool SaveUnit(Unit unit);

    }
}
