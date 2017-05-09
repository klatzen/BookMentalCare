using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.DAL
{
    public interface IRoomRepository
    {
        bool SaveRoom(Room r);

        bool DeleteRoom(int id);

        Room FindRoom(int id);

        List<Room> FindRooms();

        List<Room> getAvailableRoom(string startTime, string endTime);
    }
}
