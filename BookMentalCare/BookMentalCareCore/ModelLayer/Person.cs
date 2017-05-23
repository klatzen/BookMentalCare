using System.ComponentModel.DataAnnotations.Schema;

namespace BookMentalCareCore.ModelLayer
{
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string fName;

        public string FNAME
        {
            get { return fName; }
            set { fName = value; }
        }

        private string lName;

        public string LNAME
        {
            get { return lName; }
            set { lName = value; }
        }

        [ForeignKey("departmentId")]
        private Department department;

        public Department DEPARTMENT
        {
            get { return department; }
            set { department = value; }
        }

        private int departmentId;

        public int DEPARTMENTID
        {
            get { return departmentId; }
            set { departmentId = value; }
        }




    }
}
