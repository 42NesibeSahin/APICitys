using CityInfo_1.Entities;
using CityInfo_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CityInfo_1.DBContexts
{
    public class CityInfoContext :DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("Konya")
                {
                    Id = 1,
                    Name="Konya",
                    Description = "Nesibe Konya",

                },
                new City("Urfa")
                {
                    Id = 2,
                    Name="Urfa",
                    Description = "Fırat Urfa"
                },
                new City("Cankiri")
                {
                    Id = 3,
                    Name="Cankiri",
                    Description = "Selim Cankiri"
                });


           modelBuilder.Entity<PointOfInterest>().HasData(
               new PointOfInterest("Konya 1")
                {
                    Id = 1,
                    CityId = 1 ,
                    Name="K1",
                    Description = "Meram"
                },
                new PointOfInterest("Konya 2")
                {
                    Id = 2,
                    Name="K2",
                    CityId = 1 ,
                    Description = "Karatay"
                },
                new PointOfInterest("Urfa 1")
                {
                    Id = 3,
                    CityId = 2,
                    Name="U1",
                    Description = "Haliliye"
                },
                new PointOfInterest("Urfa 2")
                {
                    Id = 4,
                    CityId = 2,
                    Name="U2",
                    Description = "Karakopru"
                },
                new PointOfInterest("Cankiri 1")
                {
                    Id = 5,
                    CityId = 3,
                    Name="C1",
                    Description = "BayramOren"
                });
            
            base.OnModelCreating(modelBuilder);
        }
        public CityInfoContext(DbContextOptions<CityInfoContext> options):base(options) 
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
