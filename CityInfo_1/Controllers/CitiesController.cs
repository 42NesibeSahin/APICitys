using AutoMapper;
using CityInfo_1.Models;
using CityInfo_1.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo_1.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController:ControllerBase
    {
       // private readonly CitiesDataStore _citiesDataStore;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository,IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository ?? throw new ArgumentNullException(nameof(cityInfoRepository));
            _mapper=mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task< ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()                 //1.2
        {
            var cityEntities = await _cityInfoRepository.GetCitiesAsync();
            var results = new List<CityWithoutPointsOfInterestDto>();
            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name

                });
            }
            return Ok(results);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest=false)
        {
            var city=await _cityInfoRepository.GetCityAsync(id,includePointsOfInterest);

            if (city==null)
                return NotFound();
            if (includePointsOfInterest)
                return Ok(_mapper.Map<CityDto>(city));

            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
