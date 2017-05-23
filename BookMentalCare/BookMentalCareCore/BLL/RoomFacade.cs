using System.Collections.Generic;
using BookMentalCareCore.ModelLayer;
using BookMentalCareCore.DAL;

namespace BookMentalCareCore.BLL
{
    public class RoomFacade : IRoomFacade
    {
        private IRoomRepository roomRep;
        private IDepartmentFacade depFacade;
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

        public List<Room> getAvailableRoom(string startTime, string endTime)
        {
            depFacade = new DepartmentFacade();

            List<Room> availRooms = roomRep.getAvailableRoom(startTime, endTime);
            for (int i = 0; i < availRooms.Count; i++)
            {
                availRooms[i].DEPARTMENT = depFacade.FindDepartment(availRooms[i].DEPARTMENTID);
            }
            return availRooms;
        }

        public bool SaveRoom(Room r)
        {
            return roomRep.SaveRoom(r);
        }
    }
}
