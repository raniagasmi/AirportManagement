using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {
        //DBSET
        public DbSet <Flight> Flights { get; set; }
        
        public DbSet <Plane> Planes { get; set; }
        
        public DbSet <Passenger> Passengers { get; set; }
        
        public DbSet <Staff> Staffs { get; set; }
        
        public DbSet <Traveller> Travellers { get; set; }

        public DbSet <Ticket> Ticket { get; set; }

        public DbSet <ReservationTicket> ResTicket { get; set; }
    


        //chaine de cnx
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseLazyLoadingProxies();

            optionsBuilder.UseSqlServer
            (
                @"Data Source=(localdb)\mssqllocaldb; 
                Initial Catalog=Arctic5; 
                Integrated Security=true ; MultipleActiveResultSets = true"
            ); 
            base.OnConfiguring(optionsBuilder); 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //first method : with class configuration
            //modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            //second method : without class configuration
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes")
                .Property(p => p.Capacity).HasColumnName("PlaneCapacity");

            //method2: config owned type
            modelBuilder.Entity<Passenger>().OwnsOne(f => f.fullName, full =>
            {
                full.Property(p => p.FirstName).HasColumnName("PassFirstName").HasMaxLength(50);
                full.Property(p => p.LastName).HasColumnName("PassLastName").IsRequired();
            });

            //config tph (table par hierarchie) : heritage
            /*
            modelBuilder.Entity<Passenger>().
                HasDiscriminator<int>("IsTraveller")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2)
                ;
            */

            //config tpt (table par type) : heritage
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            modelBuilder.ApplyConfiguration(new ReservationConfig());
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }
    }
}
