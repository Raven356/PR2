using System;

namespace PR2
{
    class AirCompany
    {
        public uint ID { get; set; }
        public string Label { get; set; }
        public Location OfficeLocation { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompanyCipher { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Label: {Label}, Office Location: {OfficeLocation}, CreationDate: {CreationDate}, CompanyCipher: {CompanyCipher}";
        }

    }
}
