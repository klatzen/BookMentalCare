using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.ModelLayer
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string type;

        public string TYPE
        {
            get { return type; }
            set { type = value; }
        }
        private string roomNo;

        public string ROOMNO
        {
            get { return roomNo; }
            set { roomNo = value; }
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
