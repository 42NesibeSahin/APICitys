using CityInfo_1.Models;

namespace CityInfo_1
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id=1,
                    Name="Nesibe",
                    Description="Konya",
                    PointsOfInterest=new List<PointofInterestDto>()
                    {
                        new PointofInterestDto()
                        {
                            Id=1,
                            Name="N1",
                            Description="Meram",
                        },
                        new PointofInterestDto()
                        {
                            Id=2,
                            Name="N2",
                            Description="Selçuklu",
                        }
                    }
                    
                },
                new CityDto()
                {
                    Id=2,
                    Name="Şanlıurfa",
                    Description="Fırat",
                    PointsOfInterest=new List<PointofInterestDto>()
                    {
                        new PointofInterestDto()
                        {
                            Id=1,
                            Name="F1",
                            Description="Halilye",
                        }
                    }
                }
            };
        }

    }
}
