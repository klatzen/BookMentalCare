using BookMentalCareCore.ModelLayer;
using System.Collections.Generic;

namespace BookMentalCareCore.BLL
{
    public interface IRoomFacade
    {
        bool SaveRoom(Room r);

        bool DeleteRoom(int id);

        Room FindRoom(int id);

        List<Room> FindRooms();

        List<Room> getAvailableRoom(string startTime, string endTime);
    }
}
