using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace PR2
{
    class Queries
    {
        public IEnumerable<XElement> SelectAllPlanes(XDocument xDocument)
        {
            Console.WriteLine("1. Select all planes:");
            var selectAllPlanes = xDocument.Descendants("plane").Select(x => x);
            return selectAllPlanes;
        }

        public IEnumerable<XElement> CompaniesFromUkraine(XDocument xDocument)
        {
            Console.WriteLine("\n2. Select all companies from Ukraine:");
            var companiesFromUkraine = xDocument.Descendants("office_location").Where(x => x.ToString().Contains("Ukraine"));
            return companiesFromUkraine;
        }

        public IEnumerable<XElement> HelicoptersByDescending(XDocument xDocument)
        {
            Console.WriteLine("\n3. Sort helicopter's types by descending:");
            var helicoptersByDescending = from x in xDocument.Descendants("model_name")
                                          orderby x.Value descending
                                          select x;
            return helicoptersByDescending;
        }

        public IEnumerable<XElement> SelectParticularPlane(XDocument xDocument, string modelName)
        {
            Console.WriteLine("\n4. Select object from planes:");
            var particularPlane = xDocument.Descendants("plane").Where(x => x.Element("model_name").Value.Contains(modelName));
            return particularPlane;
        }

        public IEnumerable<string> SelectPlanesAndHeliesFromSameCompany(XDocument xDocument)
        {
            Console.WriteLine("\n5. Select planes and helicopters which belong to same company:");
            var aircraftFromSameCountry = from x in xDocument.Descendants("plane")
                                          from y in xDocument.Descendants("helicopter")
                                          where x.Parent.Parent.Element("company_cipher") == y.Parent.Parent.Element("company_cipher")
                                          select "Plane " + x.Element("model_name") + " and helicopter " + y.Element("model_name") + " belong to same company";
            return aircraftFromSameCountry;
        }

        public IEnumerable<XElement> SelectCompaniesWhichStartsFromLetter(XDocument xDocument, char letter)
        {
            Console.WriteLine($"\n6. Select all companies that label starts with {letter}:");
            var companiesWhichStartWhithLetter = xDocument.Descendants("label").Where(x => x.Value.StartsWith(letter));
            return companiesWhichStartWhithLetter;
        }

        public IEnumerable<XElement> SkipWhilePlaneMaxDistanceLower(XDocument xDocument, decimal lower)
        {
            Console.WriteLine($"\n7. Skip while planes max distance < {lower}:");
            return xDocument.Descendants("plane").SkipWhile(x => Decimal.Parse(x.Element("max_distance").Value) < lower);
        }

        public IEnumerable<XElement> TakeWhileLoadCapacityLower(XDocument xDocument, decimal loadCapacity)
        {
            Console.WriteLine($"\n8. Take while helicopter load capacity < {loadCapacity}:");
            return xDocument.Descendants("helicopter").TakeWhile(x => Decimal.Parse(x.Element("load_capacity").Value) < loadCapacity);
        }

        public IOrderedEnumerable<IGrouping<string, XElement>> GroupPlanesByTakeOfLength(XDocument xDocument)
        {
            Console.WriteLine("\n9. Group planes by takeof length :");
            var groupHelicoptersByCipher = from x in xDocument.Descendants("plane")
                                           group x by x.Element("takeof_length").Value into q
                                           orderby q.Key
                                           select q;
            return groupHelicoptersByCipher;
        }

        public IEnumerable<XElement> SkipFirstAndTakeTwoCompanies(XDocument xDocument)
        {
            Console.WriteLine("\n10. Skip 1 company and take 2:");
            return xDocument.Descendants("air_company").Skip(1).Take(2);
        }

        public string SelectAverageMaxDistanceFromAllAircrafts(XDocument xDocument)
        {
            Console.WriteLine("\n13. Select average max distance from all aircrafts:");
            var averageMaxDistance = xDocument.Descendants("plane").Select(p => Decimal.Parse(p.Element("max_distance").Value)).Concat(xDocument.Descendants("helicopter").Select(h =>Decimal.Parse( h.Element("max_distance").Value)));
            return $"Average max distance from all aircrafts: {averageMaxDistance.Average()}";
        }

        public IEnumerable<string> SelectPlanesAndHeliesWithParticularCondidtion(XDocument xDocument, decimal maxDistance, decimal maxHeight)
        {
            Console.WriteLine($"\n11. Select datalinks where planes max distance > {maxDistance} and helicopters max height > {maxHeight}, order by company cipher in descending order:");
            var dataLinksWithParticularCondition = from x in xDocument.Descendants("plane")
                                                   join y in xDocument.Descendants("helicopter") on x.Parent.Parent equals y.Parent.Parent
                                                   where Decimal.Parse(x.Element("max_distance").Value) > maxDistance && Decimal.Parse(y.Element("max_height").Value) > maxHeight
                                                   orderby x.Parent.Parent.Element("company_cipher").Value descending
                                                   select $"PlaneDistance = {Decimal.Parse(x.Element("max_distance").Value)}; helicopterHeight = {Decimal.Parse(y.Element("max_height").Value)}; cipher = {x.Parent.Parent.Element("company_cipher").Value}";
            return dataLinksWithParticularCondition;
        }

        public IEnumerable<XElement> SelectAllAircraftTypes(XDocument xDocument)
        {
            Console.WriteLine("\n12. Select all aircraft types:");
            var allAircraftTypes = xDocument.Descendants("plane").Select(p => p.Element("model_name")).Concat(xDocument.Descendants("helicopter").Select(x => x.Element("model_name")));
            return allAircraftTypes;
        }

        public string SelectMaxHeightOfHelicopters(XDocument xDocument)
        {
            Console.WriteLine("\n14. Select max height of helicopter:");
            return $"Max height = {xDocument.Descendants("helicopter").Max(p => Decimal.Parse(p.Element("max_height").Value))}";
        }

        public IEnumerable<string> CheckIfThereIsCompanyWithThisLabel(XDocument xDocument)
        {
            Console.WriteLine($"\n15. Check if there is an air company from Ukraine with this label:");
            bool isCompanyExists;
            List<string> labels = new List<string> { "Super Planes", "Planes", "asdaffs", "Speedy Wings", "LowCostAirlines", "Simple Planes" };
            foreach (var x in labels)
            {
                isCompanyExists = xDocument.Descendants("air_company").Where(p => p.Element("office_location").Value.Contains("Ukraine")).Select(p => p.Element("label").Value).Contains(x);
                yield return ($"The list airCompanies {(isCompanyExists ? "contains" : "doesn't contain")} <<{x}>> in companies labels where country is Ukraine");
            }
        }

    }
}
