

namespace PR2
{
    class Plane : Aircraft
    {
        public decimal WingSpan { get; set; }
        public decimal TakeofLenght { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"WingSpan: {WingSpan}, TakeofLenght: {TakeofLenght}";
        }
    }
}
