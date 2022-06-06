using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PR2
{
    class ReadFile
    {
        public XDocument ReadXmlFile()
        {
            return XDocument.Load("lists.xml");
        }
    }
}
