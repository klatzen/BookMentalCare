using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookMentalCareCore.ModelLayer;
using System.Data.SqlClient;
using System.Data.Entity;

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
            return dbContext.Rooms.Include(x=> x.DEPARTMENT).FirstOrDefault(x => x.ID == id);
        }

        public List<Room> FindRooms()
        {
            return dbContext.Rooms.Include(x => x.DEPARTMENT).ToList();
        }

        public List<Room> getAvailableRoom(string startTime, string endTime)
        {
            return dbContext.Rooms.SqlQuery("select * from Room r where id not in(select ROOMID from Booking b where b.STARTTIME between @startTime and @endTime and b.ENDTIME between @startTime and @endTime)",
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
                    tempRoom.DEPARTMENT = null;
                }
                else
                {
                    r.DEPARTMENTID = r.DEPARTMENT.ID;
                    r.DEPARTMENT = null;
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
