using AutoMapper;

namespace CityInfo_1.Profiles
{
    public class CityProfile :Profile 
    {

        public CityProfile()
        {
            CreateMap<Entities.City,Models.CityWithoutPointsOfInterestDto>();
            CreateMap<Entities.City,Models.CityDto>();
            
        }
    }
}
