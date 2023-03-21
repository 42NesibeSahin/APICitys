using CityInfo_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace CityInfo_1.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsofInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointofInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointofInterest);
        }
        [HttpGet("{pointOfInterestId}")]
        public ActionResult<PointofInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointofInterest = city.PointofInterest
                .FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointofInterest == null)
            {
                return NotFound();
            }

            return Ok(pointofInterest);
        }
    }
}
