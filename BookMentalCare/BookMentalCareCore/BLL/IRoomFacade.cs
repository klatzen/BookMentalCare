using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.BLL
{
    public interface IRoomFacade
    {
        bool SaveRoom(Room r);

        bool DeleteRoom(int id);

        Room FindRoom(int id);

        List<Room> FindRooms();
    }
}
