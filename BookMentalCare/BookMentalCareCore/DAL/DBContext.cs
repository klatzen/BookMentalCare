using BookMentalCareCore.ModelLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Employee>()
            .HasMany<Booking>(e => e.BOOKINGS)
            .WithMany(b => b.EMPLOYEES)
            .Map(cs =>
            {
                cs.MapLeftKey("EmployeeRefId");
                cs.MapRightKey("BookingRefId");
                cs.ToTable("EmpBook");
            });
            modelBuilder.Entity<Unit>()
            .HasMany<Booking>(u => u.Bookings)
            .WithMany(b => b.RESSOURCES)
            .Map(cs =>
            {
                cs.MapLeftKey("UnitRefId");
                cs.MapRightKey("BookingRefId");
                cs.ToTable("UnitBook");
            });
        }

    }
}
