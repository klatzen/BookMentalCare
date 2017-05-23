
namespace BookMentalCareCore.ModelLayer
{
    public class Patient : Person
    {
        private string medRegNo;

        public string MEDREGNO
        {
            get { return medRegNo; }
            set { medRegNo = value; }
        }
    }
}
