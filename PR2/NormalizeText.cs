using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class NormalizeText
    {
        
        public string NormalizeAirCompaniesInfo(string text)
        {
            TextInfo textInfo = new CultureInfo("en-EN", false).TextInfo;
            return textInfo.ToTitleCase(text);
        }

        public string NormalizeAircraftInfo(string text)
        {
            return text.ToUpper();
        }
    }
}
