using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMentalCareCore.DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base("MentalCareDB")
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ressource> Ressources { get; set;  }
        public DbSet<Unit> Units { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Department> Departments { get; set;}

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
