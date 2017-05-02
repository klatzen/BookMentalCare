using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.DAL
{
    public class BaseRepository
    {
        protected DBContext dbContext;

        public BaseRepository() {
            dbContext = new DBContext();
        }
    }
}
