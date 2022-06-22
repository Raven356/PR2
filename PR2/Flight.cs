using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class Flight
    {
        public int ID { get; set; }
        public Location DepartureLocation { get; set; }
        public Location DestinationLocation { get; set; }

        public override string ToString()
        {
            return $"{ DepartureLocation.Country} - { DestinationLocation.Country}";
        }
    }
}
