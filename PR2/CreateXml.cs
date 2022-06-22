using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace PR2
{
    class CreateXml
    {
        public Lists Lists { get; set; }

        delegate void CreateDocumentDelegate(XmlWriter xmlWriter);
        public void CreateFiles()
        {
            if (Lists == null || Lists.Helicopters.Count == 0 || Lists.AirCompanies.Count == 0 
                || Lists.Planes.Count == 0)
            {
                throw new ArgumentException("Failed to create file");
            }

            

            CreateDocument( CreateAirCompaniesNodes, "AirCompanies.xml");
            CreateDocument( CreatePlaneNodes, "Planes.xml");
            CreateDocument( CreateHelicopterNodes, "Helicopters.xml");
            CreateDocument( CreateFlightsNodes, "Flights.xml");
            CreateDocument( CreateConnectionsNodes, "Connections.xml");

            
        }

        private void CreateDocument(CreateDocumentDelegate createDocumentDelegate, string name)
        {
            XmlWriter xmlWriter = XmlWriter.Create(name);
            xmlWriter.WriteStartDocument();

            createDocumentDelegate.Invoke(xmlWriter);

            xmlWriter.WriteEndDocument();

            xmlWriter.Dispose();
        }

        private void CreateFlightsNodes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("flights");
            foreach(var flight in Lists.Flights)
            {
                xmlWriter.WriteStartElement("flight");

                xmlWriter.WriteAttributeString("id", flight.ID.ToString());

                CreateNode(xmlWriter, "departure_location", flight.DepartureLocation.ToString());

                CreateNode(xmlWriter, "destination_location", flight.DestinationLocation.ToString());

                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
        }

        private void CreateConnectionsNodes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("connections");
            foreach(var connection in Lists.FligtsToPlanesConnections)
            {
                xmlWriter.WriteStartElement("connection");

                CreateNode(xmlWriter, "id_plane", connection.IDPlane.ToString());

                CreateNode(xmlWriter, "id_flight", connection.IDFlight.ToString());

                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
        }

        private void CreateAirCompaniesNodes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("air_companies");

            foreach (var airCompany in Lists.AirCompanies)
            {
                xmlWriter.WriteStartElement("air_company");
                xmlWriter.WriteAttributeString("id", airCompany.ID.ToString());

                CreateNode(xmlWriter, "label", airCompany.Label);

                CreateNode(xmlWriter, "office_location", airCompany.OfficeLocation.ToString());

                CreateNode(xmlWriter, "creation_date", airCompany.CreationDate.ToString());

                CreateNode(xmlWriter, "company_cipher", airCompany.CompanyCipher.ToString());



                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndElement();
        }

        private void CreateHelicopterNodes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("helicopters");

            foreach (var helicopter in Lists.Helicopters)
            {
                
                    xmlWriter.WriteStartElement("helicopter");

                    CreateAircraftNodes(xmlWriter, helicopter);

                    CreateNode(xmlWriter, "max_height", helicopter.MaxHeight.ToString());

                    xmlWriter.WriteEndElement();
                
            }

            xmlWriter.WriteEndElement();
        }

        private void CreatePlaneNodes(XmlWriter xmlWriter)
        {
            xmlWriter.WriteStartElement("planes");

            foreach(var plane in Lists.Planes)
            {
                
                    xmlWriter.WriteStartElement("plane");

                    CreateAircraftNodes(xmlWriter, plane);

                    CreateNode(xmlWriter, "wing_span", plane.WingSpan.ToString());

                    CreateNode(xmlWriter, "takeof_length", plane.TakeofLenght.ToString());

                    xmlWriter.WriteEndElement();
                    
                
            }

            xmlWriter.WriteEndElement();
        }

        private void CreateAircraftNodes(XmlWriter xmlWriter, Aircraft aircraft )
        {
            xmlWriter.WriteAttributeString("id", aircraft.ID.ToString());

            CreateNode(xmlWriter, "model_name", aircraft.ModelName);

            CreateNode(xmlWriter, "load_capacity", aircraft.LoadCapacity.ToString());

            CreateNode(xmlWriter, "max_distance", aircraft.MaxDistance.ToString());

            CreateNode(xmlWriter, "company_cipher", aircraft.CompanyCipher);
        }

        private void CreateNode(XmlWriter xmlWriter, string name, string text)
        {
            xmlWriter.WriteStartElement(name);
            xmlWriter.WriteString(text);
            xmlWriter.WriteEndElement();
        }
    }
}
