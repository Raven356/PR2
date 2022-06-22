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

        public bool CheckCompanyCipher(string[] values, Lists lists)
        {
            return IsCompanyCipherExists(values[4], lists);
        }

        public bool CheckID(List<AirCompany> list, int ID)
        {
            foreach(var x in list)
            {
                if(x.ID == ID)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckID(List<Plane> list, int ID)
        {
            foreach (var x in list)
            {
                if (x.ID == ID)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckID(List<Helicopter> list, int ID)
        {
            foreach (var x in list)
            {
                if (x.ID == ID)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckPositivity(IEnumerable<decimal> values)
        {
            foreach(var x in values)
            {
                if(x <= 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
