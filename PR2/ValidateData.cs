using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class ValidateData
    {
        private bool IsCompanyCipherExists(string cipher, Lists lists)
        {
            foreach (var x in lists.AirCompanies)
            {
                if (x.CompanyCipher.Equals(cipher))
                    return true;
            }
            return false;
        }

        public void CheckCompanyCipher(string[] values, Lists lists)
        {
            if (!IsCompanyCipherExists(values[4], lists))
                throw new ArgumentException("No such company cipher");
        }

        public void CheckID(List<AirCompany> list, int ID)
        {
            foreach(var x in list)
            {
                if(x.ID == ID)
                {
                    throw new ArgumentException("Already existing ID");
                }
            }
        }

        public void CheckID(List<Plane> list, int ID)
        {
            foreach (var x in list)
            {
                if (x.ID == ID)
                {
                    throw new ArgumentException("Already existing ID");
                }
            }
        }

        public void CheckID(List<Helicopter> list, int ID)
        {
            foreach (var x in list)
            {
                if (x.ID == ID)
                {
                    throw new ArgumentException("Already existing ID");
                }
            }
        }

        public void CheckPositivity(IEnumerable<decimal> values)
        {
            foreach(var x in values)
            {
                if(x <= 0)
                {
                    throw new ArgumentException("On of the values was negative");
                }
            }
        }
    }
}
