using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PR2
{
    class CreateXml
    {
        public Lists Lists { get; set; }
        public void CreateFile()
        {
            if (Lists == null || Lists.Helicopters.Count == 0 || Lists.AirCompanies.Count == 0 || Lists.Planes.Count == 0)
            {
                ErrorMessage();
                return;
            }

            XmlWriter xmlWriter = XmlWriter.Create("lists.xml");

            CreateRootNode(xmlWriter);

            xmlWriter.Close();
        }

        private void CreateRootNode(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartDocument();

            CreateAirCompaniesNodes(xmlWriter);

            xmlWriter.WriteEndDocument();
        }

        private void CreateAirCompaniesNodes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("air_companies");

            foreach (var airCompany in Lists.AirCompanies)
            {
                xmlWriter.WriteStartElement("air_company");
                xmlWriter.WriteAttributeString("id", airCompany.ID.ToString());

                CreateNode(xmlWriter, "label", airCompany.Label);

                CreateNode(xmlWriter, "office_location", airCompany.Office_Location.ToString());

                CreateNode(xmlWriter, "creation_date", airCompany.CreationDate.ToString());

                CreateNode(xmlWriter, "company_cipher", airCompany.CompanyCipher.ToString());

                CreateHelicopterNodes(xmlWriter, airCompany);

                CreatePlaneNodes(xmlWriter, airCompany);

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        private void CreateHelicopterNodes(XmlWriter xmlWriter, AirCompany airCompany)
        {
            xmlWriter.WriteStartElement("helicopters");

            foreach (var helicopter in Lists.Helicopters)
            {
                if (helicopter.CompanyCipher.Equals(airCompany.CompanyCipher))
                {
                    xmlWriter.WriteStartElement("helicopter");

                    CreateAircraftNodes(xmlWriter, helicopter);

                    CreateNode(xmlWriter, "max_height", helicopter.MaxHeight.ToString());

                    xmlWriter.WriteEndElement();
                }
            }

            xmlWriter.WriteEndElement();
        }

        private void CreatePlaneNodes(XmlWriter xmlWriter, AirCompany airCompany)
        {
            xmlWriter.WriteStartElement("planes");

            foreach(var plane in Lists.Planes)
            {
                if (plane.CompanyCipher.Equals(airCompany.CompanyCipher))
                {
                    xmlWriter.WriteStartElement("plane");

                    CreateAircraftNodes(xmlWriter, plane);

                    CreateNode(xmlWriter, "wing_span", plane.WingSpan.ToString());

                    CreateNode(xmlWriter, "takeof_length", plane.TakeofLenght.ToString());

                    xmlWriter.WriteEndElement();
                    
                }
            }

            xmlWriter.WriteEndElement();
        }

        private void CreateAircraftNodes(XmlWriter xmlWriter, Aircraft aircraft )
        {
            xmlWriter.WriteAttributeString("id", aircraft.ID.ToString());

            CreateNode(xmlWriter, "model_name", aircraft.ModelName);

            CreateNode(xmlWriter, "load_capacity", aircraft.LoadCapacity.ToString());

            CreateNode(xmlWriter, "max_distance", aircraft.MaxDistance.ToString());
        }

        private void CreateNode(XmlWriter xmlWriter, string name, string text)
        {
            xmlWriter.WriteStartElement(name);
            xmlWriter.WriteString(text);
            xmlWriter.WriteEndElement();
        }

        private void ErrorMessage()
        {
            throw new ArgumentException("Failed to create file");
        }
    }
}
