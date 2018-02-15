using CityAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI
{
    public class CitiesDataStore
    {

        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "City in USA",
                    PointsOfInterest = new List<PointOfInterestDto>
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "Park"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "Building"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "City in Belgium",
                                 PointsOfInterest = new List<PointOfInterestDto>        {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "Cathedral"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "Central Station",
                            Description = "Station"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "City in France",
                    PointsOfInterest = new List<PointOfInterestDto>        {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Eiffel Tower Park",
                            Description = "Tower"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "Museum"
                        }
                    }
                }
            };
        }

    }
}
