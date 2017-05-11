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
        //lille ændring
        Ressource LoadRessource(int id);
        List<Ressource> LoadAllRessources();
        bool SaveRessource(Ressource ressource);
        bool RemoveRessource(int id);
        List<Unit> LoadAllUnits(int resId);
        Unit LoadUnit(int id);
        bool RemoveUnit(int id);
        bool SaveUnit(Unit unit);

        List<Ressource> LoadAvalibleUnits(string startDate, string endDate);

    }
}
