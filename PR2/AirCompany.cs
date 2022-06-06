

namespace PR2
{
    class AirCompany
    {
        public uint ID { get; set; }
        public string Label { get; set; }
        public OfficeLocation Office_Location { get; set; }
        public string CreationDate { get; set; }
        public string CompanyCipher { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Label: {Label}, Office Location: {Office_Location}, CreationDate: {CreationDate}, CompanyCipher: {CompanyCipher}";
        }

    }
}
