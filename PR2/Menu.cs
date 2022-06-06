using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class Menu
    {
        public Lists StartMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Do you want to enter values from keyboard? Y/N");
                try
                {
                    string answer = Console.ReadLine();
                    Console.Clear();
                    if (answer.Equals("Y"))
                        return new EnterData().EnterValues();
                    if (!answer.Equals("N"))
                        throw new ArgumentException("Wrong Input");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                return new Lists();
            }
        }
    }
}
