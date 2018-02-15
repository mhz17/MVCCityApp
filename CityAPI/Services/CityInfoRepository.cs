using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {

        private CityInfoContext _context;
        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(p => p.Name).ToList();
        }

        public bool CityExists(int cityID)
        {
            return _context.Cities.Any(c => c.Id == cityID);
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
           if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(p => p.Id == cityId)
                    .FirstOrDefault();
            }

                return _context.Cities
                    .Where(p => p.Id == cityId)
                    .FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointofInterestId)
        {
            return _context.PointsOfInterest
                .Where(p => p.Id == pointofInterestId && p.CityId == cityId)
                .FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest
             .Where(p => p.CityId == cityId)
             .ToList();
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
            Save();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
    }
}
