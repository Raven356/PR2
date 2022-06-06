

namespace PR2
{
    class OfficeLocation
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public override string ToString()
        {
            return $"Country: {Country}, City: {City}, Street: {Street}, Bulding number: {Number}";
        }

    }
}
