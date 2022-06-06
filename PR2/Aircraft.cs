using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class Aircraft
    {
        public uint ID { get; set; }
        public string ModelName { get; set; }
        public decimal LoadCapacity { get; set; }
        public decimal MaxDistance { get; set; }
        public string CompanyCipher { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Model name: {ModelName}, LoadCapacity: {LoadCapacity}, MaxDistance: {MaxDistance}, CompanyCipher: {CompanyCipher}, ";
        }

    }
}
