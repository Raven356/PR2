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
                    createXML.CreateFile();

                    XDocument xDocument = new ReadFile().ReadXmlFile();

                    PrintDocumentOnScreen printDocument = new PrintDocumentOnScreen();
                    printDocument.PrintDocument(xDocument);

                    ExecuteQueries executeQueries = new ExecuteQueries();
                    executeQueries.Execute(xDocument);

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
