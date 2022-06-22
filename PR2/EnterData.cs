using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class EnterData
    {
        readonly Lists _lists = new Lists();
        delegate void EnterDataDelegate(string[] name);
        readonly ValidateData _validateData = new ValidateData();
        readonly NormalizeText _normalizeText = new NormalizeText();

        public Lists EnterValues()
        {
            new ClearLists().ClearAllLists(_lists);
            Console.Clear();
            try
            {
                EnterNewValues("air companies", EnterAirCompanies);
                Console.Clear();
                EnterNewValues("helicopters", EnterHelicopter);
                Console.Clear();
                EnterNewValues("planes", EnterPlane);
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

            return _lists;
        }

        private void EnterNewValues(string name, EnterDataDelegate enterData)
        {
            while (true)
            {
                Console.WriteLine($"Do you want to enter {name}? Y/N ");
                string choice;
                try
                {
                    choice = Console.ReadLine();
                    if (!choice.Equals("Y") && !choice.Equals("N"))
                        throw new ArgumentException("Wrong input");
                    if (choice.Equals("N"))
                        return;
                    enterData.Invoke(EnterNodes(name));
                    Console.Clear();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void EnterHelicopter(string[] values)
        {
            if(!_validateData.CheckID(_lists.Helicopters, int.Parse(values[0])))
            {
                throw new ArgumentException("Already existing ID");
            }
            if(!_validateData.CheckPositivity(new List<decimal>{ decimal.Parse(values[2]), decimal.Parse(values[3]), decimal.Parse(values[5])}))
            {
                throw new ArgumentException("On of the values was negative");
            }
            if(!_validateData.CheckCompanyCipher(values, _lists))
            {
                throw new ArgumentException("No such company cipher");
            }
            _lists.Helicopters.Add(new Helicopter { ID = uint.Parse(values[0]), ModelName = _normalizeText.NormalizeAircraftInfo( values[1]), LoadCapacity = Decimal.Parse(values[2]), MaxDistance = Decimal.Parse(values[3]), CompanyCipher = _normalizeText.NormalizeAircraftInfo( values[4]), MaxHeight = Decimal.Parse(values[5]) });
            
        }

        private void EnterPlane(string[] values)
        {
            if(!_validateData.CheckID(_lists.Planes, int.Parse(values[0])))
            {
                throw new ArgumentException("Already existing ID");
            }
            if(!_validateData.CheckPositivity(new List<decimal> { decimal.Parse(values[2]), decimal.Parse(values[3]), decimal.Parse(values[5]), decimal.Parse(values[6]) }))
            {
                throw new ArgumentException("On of the values was negative");
            }
            if(!_validateData.CheckCompanyCipher(values, _lists))
            {
                throw new ArgumentException("No such company cipher");
            }
            _lists.Planes.Add(new Plane { ID = uint.Parse(values[0]), ModelName = _normalizeText.NormalizeAircraftInfo(values[1]), LoadCapacity = Decimal.Parse(values[2]), MaxDistance = Decimal.Parse(values[3]), CompanyCipher = _normalizeText.NormalizeAircraftInfo( values[4]), WingSpan = Decimal.Parse(values[5]), TakeofLenght = Decimal.Parse(values[6]) });
            
        }

        private void EnterAirCompanies(string[] values)
        {
            if(!_validateData.CheckID(_lists.AirCompanies, int.Parse(values[0])))
            {
                throw new ArgumentException("Already existing ID");
            }
            _lists.AirCompanies.Add(new AirCompany { ID = uint.Parse(values[0]), Label = _normalizeText.NormalizeAirCompaniesInfo(values[1]), OfficeLocation = new Location() { Country = _normalizeText.NormalizeAirCompaniesInfo(values[2]), City = _normalizeText.NormalizeAirCompaniesInfo(values[3]), Street = _normalizeText.NormalizeAirCompaniesInfo(values[4]), Number = _normalizeText.NormalizeAirCompaniesInfo(values[5]) }, CreationDate = DateTime.Parse(values[6]), CompanyCipher = _normalizeText.NormalizeAircraftInfo(values[7]) });
        }

        private string[] EnterNodes(string listName)
        {
            Console.WriteLine($"Please enter data for list of {listName} in this format:\nnumber1, number2, number3, ..., numberX");
            try
            {
                string input = Console.ReadLine();

                if(input.Split(", ").Length != 6 && listName.Equals("helicopters") || input.Split(", ").Length != 7 && listName.Equals("planes") || input.Split(", ").Length != 8 && listName.Equals("air companies") )
                {
                    throw new FormatException("Wrong amount of elements");
                }
                return input.Split(", ");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return "".Split(" ");
            }
        }
    }
}
