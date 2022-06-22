using System;
using System.Xml.Linq;

namespace PR2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    CreateXml createXML = new CreateXml { Lists = new Menu().StartMenu()};
                    createXML.CreateFiles();

                    ReadFile readFile = new ReadFile();
                    PrintDocumentOnScreen printDocument = new PrintDocumentOnScreen();
                    printDocument.PrintDocument(readFile.ReadXmlFile("AirCompanies.xml")
                        , readFile.ReadXmlFile("Connections.xml")
                        , readFile.ReadXmlFile("Flights.xml")
                        , readFile.ReadXmlFile("Helicopters.xml")
                        , readFile.ReadXmlFile("Planes.xml"));

                    ExecuteQueries executeQueries = new ExecuteQueries();
                    executeQueries.Execute();

                    new ContinueProgram().Continue();
                    Console.Clear();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                
            }
        }
    }
}
