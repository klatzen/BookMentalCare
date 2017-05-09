using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using System.Data.SqlClient;

namespace BookMentalCareCore.DAL
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public bool DeleteRoom(int id)
        {
            try
            {
                Room tempRoom = FindRoom(id);
                dbContext.Rooms.Remove(tempRoom);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Room FindRoom(int id)
        {
            return dbContext.Rooms.FirstOrDefault(x => x.ID == id);
        }

        public List<Room> FindRooms()
        {
            return dbContext.Rooms.ToList();
        }

        public List<Room> getAvailableRoom(string startTime, string endTime)
        {
            return dbContext.Rooms.SqlQuery("select * from Room r where id not in(select ROOM_ID from Booking b where b.STARTTIME between @startTime and @endTime and b.ENDTIME between @startTime and @endTime)",
                new SqlParameter("startTime", startTime),
                new SqlParameter("endTime", endTime))
                .ToList();
        }

        public bool SaveRoom(Room r)
        {
            try
            {
                if (r.ID > 0)
                {
                    Room tempRoom = FindRoom(r.ID);
                    tempRoom.TYPE = r.TYPE;
                    tempRoom.ROOMNO = r.ROOMNO;
                }
                else
                {
                    dbContext.Rooms.Add(r);
                }
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
