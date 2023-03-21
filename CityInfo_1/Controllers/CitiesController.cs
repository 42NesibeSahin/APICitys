using CityInfo_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo_1.Controllers
{
    [ApiController]
    [Route("api/cities")]//("api/[controller]")
    public class CitiesController:ControllerBase
    {
        [HttpGet]//("api/cities")
        //public JsonResult GetCities()                                      // 1.1
        //{
        //    //return new JsonResult(new List<object>                       // 1.1.1
        //    //{
        //    //    new{id=1, Name="Konya"},
        //    //    new{id=2, Name="Urfa"}
        //    //});
        //    return new JsonResult(CitiesDataStore.Current.Cities);          // 1.1.2
        //}
        public ActionResult<IEnumerable<CityDto>> GetCities()                 //1.2
        {
            //return new JsonResult(new List<object>
            //{
            //    new{id=1, Name="Konya"},
            //    new{id=2, Name="Urfa"}
            //});
            return Ok(CitiesDataStore.Current.Cities);
        }


        [HttpGet("{id}")]
        //public JsonResult GetCity(int id)
        //{
        //    return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c=>c.Id==id));
        //}

        public ActionResult<CityDto> GetCity(int id)
        {

            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            if (cityToReturn == null)
            {
                return NotFound();
            }
            return Ok(cityToReturn);
        }
    }
}
