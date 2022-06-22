using System;
using System.Collections.Generic;

namespace PR2
{
    class Lists
    {
        public List<Plane> Planes { get; set; } = new List<Plane>()
        {
            new Plane{  ID = 1, ModelName = "ANTONOV95"
                , LoadCapacity = 124
                , MaxDistance = 1000
                , CompanyCipher = "GD86700"
                , WingSpan = 120
                , TakeofLenght = 5 },
            new Plane{  ID = 2, ModelName = "AIRBUS"
                , LoadCapacity = 15000
                , MaxDistance = 4000
                , CompanyCipher = "RD93200"
                , WingSpan = 100
                , TakeofLenght = 3 },
            new Plane{  ID = 3, ModelName = "TYPOLEV49"
                , LoadCapacity = 20000
                , MaxDistance = 10000
                , CompanyCipher = "TY09547"
                , WingSpan = 150
                , TakeofLenght = 10 },
            new Plane{  ID = 4, ModelName = "SU67"
                , LoadCapacity = 2100
                , MaxDistance = 12344
                , CompanyCipher = "RD93200"
                , WingSpan = 90
                , TakeofLenght = 2 },
            new Plane{  ID = 5, ModelName = "IL76"
                , LoadCapacity = 5000
                , MaxDistance = 100000
                , CompanyCipher = "YT74892"
                , WingSpan = 140
                , TakeofLenght = 10 }
        };

        public List<Helicopter> Helicopters { get; set; } = new List<Helicopter>()
        {
            new Helicopter{ ID = 1, ModelName = "BLACKEAGLE"
                , LoadCapacity = 1000
                , MaxDistance = 400
                , CompanyCipher = "RD93200"
                , MaxHeight = 500 },
            new Helicopter{ ID = 2, ModelName = "TAI84"
                , LoadCapacity = 1284
                , MaxDistance = 480
                , CompanyCipher = "YT74892"
                , MaxHeight = 668.7m },
            new Helicopter{ ID = 3, ModelName = "RT721"
                , LoadCapacity = 2343
                , MaxDistance = 2341
                , CompanyCipher = "GD86700"
                , MaxHeight = 912 },
            new Helicopter{ ID = 4, ModelName = "YRE32"
                , LoadCapacity = 3242
                , MaxDistance = 2212
                , CompanyCipher = "GD86700"
                , MaxHeight = 1241 },
            new Helicopter{ ID = 5, ModelName = "WER12"
                , LoadCapacity = 9234
                , MaxDistance = 1241
                , CompanyCipher = "TY09547"
                , MaxHeight = 2112.54M }
        };

        public List<AirCompany> AirCompanies { get; set; } = new List<AirCompany>()
        {
            new AirCompany{ ID = 1, Label = "Super Planes"
                , OfficeLocation = new Location(){Country = "Ukraine"
                    , City = "Mariupol"
                    , Street = "Metalurgiv"
                    , Number = "27B"}
                , CreationDate = DateTime.Parse("27-01-1987")
                , CompanyCipher = "GD86700" },
            new AirCompany{ ID = 2, Label = "Speedy Wings"
                , OfficeLocation = new Location(){Country = "USA"
                    , City = "Washington DC"
                    , Street = "27Avenue"
                    , Number = "148"}
                , CreationDate = DateTime.Parse("21-01-1949")
                , CompanyCipher = "RD93200" },
            new AirCompany{ ID = 3, Label = "Normal Planes"
                , OfficeLocation = new Location() { Country = "UK"
                    , City = "London"
                    , Street = "History st"
                    , Number = "45" }
                , CreationDate = DateTime.Parse("04-08-1989")
                , CompanyCipher = "TY09547" },
            new AirCompany{ ID = 4, Label = "Low Cost Airlines"
                , OfficeLocation = new Location() { Country = "Ukraine"
                    , City = "Kyiv"
                    , Street = "Shevchenka"
                    , Number = "24" }
                , CreationDate = DateTime.Parse("19-12-2004")
                , CompanyCipher = "YT74892" }
        };

        public List<Flight> Flights { get; set; } = new List<Flight>()
        {
            new Flight{ID = 1, DepartureLocation = new Location {Country = "Ukraine"
                , City = "Mariupol"
                , Street = "Budivelnikiv"
                , Number = "2"}
            , DestinationLocation = new Location{ Country = "Turkey"
                , City = "Ankara"
                , Street = "Veryturkishstreet"
                , Number = "12" }
            },
            new Flight{ID = 2, DepartureLocation = new Location{ Country = "USA"
                , City = "Washington DC"
                , Street = "27Avenue"
                , Number = "12"}
            , DestinationLocation = new Location{ Country = "Ukraine"
                , City = "Kyiv"
                , Street = "Shevchenka"
                , Number = "45" }
            }
        };

        public List<FligtsToPlanes> FligtsToPlanesConnections { get; set; } = new List<FligtsToPlanes>
        {
            new FligtsToPlanes { IDPlane = 1, IDFlight = 1},
            new FligtsToPlanes { IDPlane = 1, IDFlight = 2},
            new FligtsToPlanes { IDPlane = 2, IDFlight = 1},
            new FligtsToPlanes { IDPlane = 3, IDFlight = 2},
            new FligtsToPlanes { IDPlane = 4, IDFlight = 1},
            new FligtsToPlanes { IDPlane = 4, IDFlight = 2},
            new FligtsToPlanes { IDPlane = 5, IDFlight = 1},
            new FligtsToPlanes { IDPlane = 5, IDFlight = 2 }
        };
    }
}
