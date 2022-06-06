using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PR2
{
    class PrintDocumentOnScreen
    {
        public void PrintDocument(XDocument xDocument)
        {
            Console.WriteLine(xDocument);
        }
    }
}
