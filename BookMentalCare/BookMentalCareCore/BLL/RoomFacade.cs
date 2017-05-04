using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using BookMentalCareCore.DAL;

namespace BookMentalCareCore.BLL
{
    public class RoomFacade : IRoomFacade
    {
        private IRoomRepository roomRep;
        public RoomFacade()
        {
            roomRep = new RoomRepository();
        }
        public bool DeleteRoom(int id)
        {
            return roomRep.DeleteRoom(id);
        }

        public Room FindRoom(int id)
        {
            return roomRep.FindRoom(id);
        }

        public List<Room> FindRooms()
        {
            return roomRep.FindRooms();
        }

        public bool SaveRoom(Room r)
        {
            return roomRep.SaveRoom(r);
        }
    }
}
