using AutoMapper;
using CityAPI.Models;
using CityAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI.Controllers
{
    [Route("api/cities")]
    public class CitiesController: Controller
    {
        private ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

       [HttpGet]
       public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            //var results = new List<CityWithoutPointsOfInterestDto>();

            //foreach(var cityEntity in cityEntities)
            //{
            //    results.Add(new CityWithoutPointsOfInterestDto
            //    {
            //        Id = cityEntity.Id,
            //        Name = cityEntity.Name,
            //        Description = cityEntity.Description,
            //    });
            //}

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {

            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);

            if (city == null)
            {
                return NotFound();
            }

            if (includePointsOfInterest)
            {

                //var cityResult = new CityDto()
                //{
                //    Id = city.Id,
                //    Name = city.Name,
                //    Description = city.Description
                //};

                //foreach (var poi in city.PointsOfInterest)
                //{
                //    cityResult.PointsOfInterest.Add(new PointOfInterestDto
                //    {
                //        Id = poi.Id,
                //        Name = poi.Name,
                //        Description = poi.Description
                //    });
                //}
                var cityResult = Mapper.Map<CityDto>(city);
                return Ok(cityResult);

            }

            //var cityResultWithoutPointOfInterest = new CityWithoutPointsOfInterestDto()
            //{
            //    Id = city.Id,
            //    Name = city.Name,
            //    Description = city.Description
            //};
            var cityResultWithoutPointOfInterest = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(cityResultWithoutPointOfInterest);

            //var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            //if (cityToReturn == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Ok(cityToReturn);
            //}
        }
    }
}
