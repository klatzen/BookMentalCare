
namespace BookMentalCareCore.DAL
{
    public class BaseRepository
    {
        protected DBContext dbContext;

        public BaseRepository()
        {
            dbContext = new DBContext();
        }
    }
}
