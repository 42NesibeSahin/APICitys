using AutoMapper;

namespace CityInfo_1.Profiles
{
    public class PointOfInterestProfile: Profile
    {
        public PointOfInterestProfile()
        {
            CreateMap<Entities.PointOfInterest, Models.PointofInterestDto>();
            CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
            CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>(); 
            CreateMap<Entities.PointOfInterest,Models.PointOfInterestForUpdateDto>();
        
        }
    }
}
