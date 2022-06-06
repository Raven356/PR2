using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PR2
{
    class ExecuteQueries
    {
        public void Execute(XDocument xDocument)
        {
            Queries queries = new Queries();
            PrintQuerie print = new PrintQuerie();

            print.Print(queries.SelectAllPlanes(xDocument));

            print.Print(queries.CompaniesFromUkraine(xDocument));

            print.Print(queries.HelicoptersByDescending(xDocument));

            print.Print(queries.SelectParticularPlane(xDocument, "Airbus"));

            print.Print(queries.SelectPlanesAndHeliesFromSameCompany(xDocument));

            print.Print(queries.SelectCompaniesWhichStartsFromLetter(xDocument, 'S'));

            print.Print(queries.SkipWhilePlaneMaxDistanceLower(xDocument, 10000));

            print.Print(queries.TakeWhileLoadCapacityLower(xDocument, 3000m));

            print.Print(queries.GroupPlanesByTakeOfLength(xDocument));

            print.Print(queries.SkipFirstAndTakeTwoCompanies(xDocument));

            print.Print(queries.SelectPlanesAndHeliesWithParticularCondidtion(xDocument, 500m, 1000m));

            print.Print(queries.SelectAllAircraftTypes(xDocument));

            print.Print(queries.SelectAverageMaxDistanceFromAllAircrafts(xDocument));

            print.Print(queries.SelectMaxHeightOfHelicopters(xDocument));

            print.Print(queries.CheckIfThereIsCompanyWithThisLabel(xDocument));
        }
    }
}
