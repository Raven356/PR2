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
            _validateData.CheckID(_lists.Helicopters, int.Parse(values[0]));
            _validateData.CheckPositivity(new List<decimal>{ decimal.Parse(values[2]), decimal.Parse(values[3]), decimal.Parse(values[5])});
            _validateData.CheckCompanyCipher(values, _lists);
            _lists.Helicopters.Add(new Helicopter { ID = uint.Parse(values[0]), ModelName = values[1], LoadCapacity = Decimal.Parse(values[2]), MaxDistance = Decimal.Parse(values[3]), CompanyCipher = values[4], MaxHeight = Decimal.Parse(values[5]) });
            
        }

        private void EnterPlane(string[] values)
        {
            _validateData.CheckID(_lists.Planes, int.Parse(values[0]));
            _validateData.CheckPositivity(new List<decimal> { decimal.Parse(values[2]), decimal.Parse(values[3]), decimal.Parse(values[5]), decimal.Parse(values[6]) });
            _validateData.CheckCompanyCipher(values, _lists);
            _lists.Planes.Add(new Plane { ID = uint.Parse(values[0]), ModelName = values[1], LoadCapacity = Decimal.Parse(values[2]), MaxDistance = Decimal.Parse(values[3]), CompanyCipher = values[4], WingSpan = Decimal.Parse(values[5]), TakeofLenght = Decimal.Parse(values[6]) });
            
        }

        private void EnterAirCompanies(string[] values)
        {
            _validateData.CheckID(_lists.AirCompanies, int.Parse(values[0]));
            _lists.AirCompanies.Add(new AirCompany { ID = uint.Parse(values[0]), Label = values[1], Office_Location = new OfficeLocation() { Country = values[2], City = values[3], Street = values[4], Number = values[5] }, CreationDate = values[6], CompanyCipher = values[7] });
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
