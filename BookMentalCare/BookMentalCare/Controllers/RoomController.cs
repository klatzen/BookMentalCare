using BookMentalCareCore.BLL;
using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookMentalCare.Controllers
{
    public class RoomController : ApiController
    {
        private IRoomFacade roomFacade;
        public RoomController()
        {
            roomFacade = new RoomFacade();
        }
        // GET: api/Room
        public IEnumerable<Room> Get()
        {
            return roomFacade.FindRooms();
        }

        // GET: api/Room/5
        public Room Get(int id)
        {
            return roomFacade.FindRoom(id);
        }

        // POST: api/Room
        [HttpGet,HttpPut]
        public void Post([FromBody]Room room)
        {
            roomFacade.SaveRoom(room);
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
            roomFacade.DeleteRoom(id);
        }
    }
}
