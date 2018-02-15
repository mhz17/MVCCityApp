using CityAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityAPI
{
    public static class CityInfoExtensions
    {
       
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

           var cities = new List<City>
            {
                new City()
                {
                    Name = "New York City",
                    Description = "City in USA",
                    PointsOfInterest = new List<PointOfInterest>
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "Park"
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "Building"
                        }
                    }
                },
                new City()
                {
                    Name = "Antwerp",
                    Description = "City in Belgium",
                        PointsOfInterest = new List<PointOfInterest>        {
                        new PointOfInterest()
                        {
                            Name = "Cathedral of Our Lady",
                            Description = "Cathedral"
                        },
                        new PointOfInterest()
                        {
                            Name = "Central Station",
                            Description = "Station"
                        }
                    }
                },
                new City()
                {
                    Name = "Paris",
                    Description = "City in France",
                    PointsOfInterest = new List<PointOfInterest>        {
                        new PointOfInterest()
                        {
                            Name = "Eiffel Tower Park",
                            Description = "Tower"
                        },
                        new PointOfInterest()
                        {
                            Name = "The Louvre",
                            Description = "Museum"
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges(true);
        }
    }
}
