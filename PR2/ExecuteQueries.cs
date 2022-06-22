using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PR2
{
    class ExecuteQueries
    {
        public void Execute()
        {
            Queries queries = new Queries();
            PrintQuerie print = new PrintQuerie();

            print.Print("1. Select all planes:");
            print.Print(queries.SelectAllPlanes());

            print.Print("\n2. Select all companies from Ukraine:");
            print.Print(queries.CompaniesFromUkraine());

            print.Print("\n3. Sort helicopter's types by descending:");
            print.Print(queries.HelicoptersByDescending());

            print.Print("\n4. Select object from planes:");
            print.Print(queries.SelectParticularPlane("Airbus"));

            print.Print("\n5. Select planes and helicopters which belong to same company:");
            print.Print(queries.SelectHeliesAndPlanesWithSameCompanyCipher());

            print.Print($"\n6. Select all companies that label starts with S:");
            print.Print(queries.SelectCompaniesWhichStartsFromLetter('S'));

            print.Print($"\n7. Skip while planes max distance < 10000:");
            print.Print(queries.SkipWhilePlaneMaxDistanceLower(10000));

            print.Print($"\n8. Take while helicopter load capacity < 3000:");
            print.Print(queries.TakeWhileLoadCapacityLower(3000m));

            print.Print("\n 9.Group helicopters by company cipher: ");
            print.Print(queries.GroupHeliesByCompanyCipher());

            print.Print("\n10. Group planes by flights:");
            print.Print(queries.GroupPlanesByFlights());

            print.Print($"\n11. Select air companies where planes max distance > 500 and helicopters max height > 1000, order by company cipher in descending order:");
            print.Print(queries.SelectAirCompaniesWithParticularCondidtion(500m, 1000m));

            print.Print("\n12. Select all aircraft types:");
            print.Print(queries.SelectAllAircraftTypes());

            print.Print("\n13. Select average max distance from all aircrafts:");
            print.Print(queries.SelectAverageMaxDistanceFromAllAircrafts());

            print.Print("\n14. Select max height of helicopter:");
            print.Print(queries.SelectMaxHeightOfHelicopters());

            print.Print($"\n15. Check if there is an air company from Ukraine with this label:");
            print.Print(queries.CheckIfThereIsCompanyWithThisLabel());
        }
    }
}
