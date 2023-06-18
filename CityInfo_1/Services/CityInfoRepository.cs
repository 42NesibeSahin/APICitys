using CityInfo_1.DBContexts;
using CityInfo_1.Entities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace CityInfo_1.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {

        private  readonly CityInfoContext _context;

        public CityInfoRepository( CityInfoContext context)
        {
            _context= context?? throw new ArgumentNullException(nameof(context));
        }

        public  async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(o => o.Name).ToListAsync();
        }

        public  async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
                return  await _context.Cities.Include(i=>i.PointsOfInterest)
                    .Where(w=>w.Id== cityId).FirstOrDefaultAsync();
         
            return await _context.Cities.Where(w=>w.Id == cityId).FirstOrDefaultAsync();
        }

        public async Task<bool> CityExistAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(c=>c.Id== cityId);
        }

        public  async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityId, int pointOfInterestId)
        {
            return await _context.PointsOfInterest
                .Where(w => w.CityId == cityId && w.Id == pointOfInterestId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId)
        {
            return await _context.PointsOfInterest
                .Where(w => w.CityId == cityId)
                .ToListAsync();
        }

        public async Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);
            if (city != null)
                city.PointsOfInterest.Add(pointOfInterest);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
    }
}
