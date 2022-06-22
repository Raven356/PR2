using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace PR2
{
    class Queries
    {
        readonly XDocument AirCompaniesDocument = XDocument.Load("AirCompanies.xml");
        readonly XDocument ConnectionsDocument = XDocument.Load("Connections.xml");
        readonly XDocument FlightsDocument = XDocument.Load("Flights.xml");
        readonly XDocument HelicoptersDocument = XDocument.Load("Helicopters.xml");
        readonly XDocument PlanesDocument = XDocument.Load("Planes.xml");
        public IEnumerable<XElement> SelectAllPlanes()
        {
            return PlanesDocument.Descendants("planes");
        }

        public IEnumerable<XElement> CompaniesFromUkraine()
        {
            var companiesFromUkraine = AirCompaniesDocument.Descendants("air_company")
                .Where(x => x
                    .Element("office_location")
                    .Value
                    .Contains("Ukraine"));
            return companiesFromUkraine;
        }

        public IEnumerable<XElement> HelicoptersByDescending()
        {

            var helicoptersByDescending = from x in HelicoptersDocument.Descendants("helicopter")
                                          orderby x.Element("model_name").Value descending
                                          select x;
            return helicoptersByDescending;
        }

        public IEnumerable<XElement> SelectParticularPlane(string plane)
        {

            var particularPlane = PlanesDocument.Descendants("plane")
                .Where((x) => { return x
                    .Element("model_name")
                    .Value
                    .Equals(plane); });
            return particularPlane;
        }

        public Dictionary<string, List<HelicoptersWithPlanes>> SelectHeliesAndPlanesWithSameCompanyCipher()
        {

            var heliesAndPlanesWithSameCompanyCipher = from x in HelicoptersDocument.Descendants("helicopter")
                                                       join y in PlanesDocument.Descendants("plane")
                                                         on x.Element("company_cipher")
                                                         equals y.Element("company_cipher")
                                                       group new HelicoptersWithPlanes { Plane = y, Helicopter = x }
                                                         by x.Element("company_cipher").Value
                                            into grouped
                                                       select grouped;

            return heliesAndPlanesWithSameCompanyCipher.ToDictionary(x => x.Key, x => x.ToList());
        }


        public IEnumerable<XElement> SelectCompaniesWhichStartsFromLetter(char letter)
        {

            var companiesWhichStartWhithLetter = AirCompaniesDocument
                .Descendants("air_company")
                .Where(x => x
                    .Element("label")
                    .Value
                    .StartsWith(letter));
            return companiesWhichStartWhithLetter;
        }

        public IEnumerable<XElement> SkipWhilePlaneMaxDistanceLower( decimal lower)
        {

            return PlanesDocument
                .Descendants("plane")
                .SkipWhile(x => decimal
                    .Parse( x
                        .Element("max_distance")
                        .Value) < lower);
        }

        public IEnumerable<XElement> TakeWhileLoadCapacityLower( decimal loadCapacity)
        {

            return HelicoptersDocument
                .Descendants("helicopter")
                .TakeWhile(x => decimal
                    .Parse( x
                        .Element("load_capacity")
                        .Value) < loadCapacity);
        }

        public Dictionary<string, List<XElement>> GroupHeliesByCompanyCipher()
        {

            var groupHelicoptersByCipher = from x in HelicoptersDocument.Descendants("helicopter")
                                           group x by x.Element("company_cipher").Value into q
                                           select q;
            return groupHelicoptersByCipher.ToDictionary(x => x.Key, x => x.ToList());
        }

        public Dictionary<string, List<XElement>> GroupPlanesByFlights()
        {
            var groupPlanesByFlights = from x in PlanesDocument
                                        .Descendants("plane")
                                       join y in ConnectionsDocument
                                        .Descendants("connection") 
                                            on x.Attribute("id")
                                            .Value 
                                                equals y.Element("id_plane").Value
                                       join z in FlightsDocument
                                        .Descendants("flight") 
                                            on y.Element("id_flight").Value 
                                                equals z.Attribute("id").Value
                                       group x by z.ToString() into groupedPlanesByFlights
                                       select groupedPlanesByFlights;
            return groupPlanesByFlights.ToDictionary(x => x.Key, x => x.ToList());
        }

        public decimal SelectAverageMaxDistanceFromAllAircrafts()
        {

            var averageMaxDistance = PlanesDocument.Descendants("plane")
                .Select(p => decimal
                    .Parse( p
                        .Element("max_distance")
                        .Value))
                .Concat(HelicoptersDocument
                    .Descendants("helicopter")
                        .Select(h => decimal
                            .Parse(h.Element("max_distance")
                                .Value)));
            return averageMaxDistance.Average();
        }

        public IEnumerable<XElement> SelectAirCompaniesWithParticularCondidtion( decimal maxDistance, decimal maxHeight)
        {

            var airCompaniesWithParticularCondition = from q in AirCompaniesDocument.Descendants("air_company")
                                                      join y in PlanesDocument.Descendants("plane") 
                                                        on q.Element("company_cipher").Value 
                                                            equals y.Element("company_cipher").Value
                                                      join z in HelicoptersDocument.Descendants("helicopter") 
                                                        on q.Element("company_cipher").Value 
                                                            equals z.Element("company_cipher").Value
                                                      where decimal.Parse( y.Element("max_distance").Value) 
                                                            > maxDistance 
                                                        && decimal.Parse( z.Element("max_height").Value) 
                                                            > maxHeight
                                                      orderby q.Element("company_cipher").Value descending
                                                      select q;
            return airCompaniesWithParticularCondition;
        }

        public IEnumerable<string> SelectAllAircraftTypes()
        {

            var allAircraftTypes = PlanesDocument.Descendants("plane")
                .Select(p => p.Element("model_name").Value)
                .Concat(HelicoptersDocument.Descendants("helicopter")
                    .Select(x => x.Element("model_name").Value));
            return allAircraftTypes;
        }


        public decimal SelectMaxHeightOfHelicopters()
        {

            return HelicoptersDocument.Descendants("helicopter")
                .Max(p => decimal.Parse( p.Element("max_height").Value));
        }

        public IEnumerable<bool> CheckIfThereIsCompanyWithThisLabel()
        {

            bool isCompanyExists;
            List<string> labels = 
                new List<string> { "Super Planes"
                    , "Planes"
                    , "asdaffs"
                    , "Speedy Wings"
                    , "Low Cost Airlines"
                    , "Simple Planes" };
            foreach (var x in labels)
            {
                isCompanyExists = AirCompaniesDocument.Descendants("air_company")
                    .Where(p => p
                        .Element("office_location")
                        .Value
                        .Contains("Ukraine"))
                    .Select(p => p
                        .Element("label")
                        .Value)
                    .Contains(x);
                yield return isCompanyExists;
            }
        }

    }
}
