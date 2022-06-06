using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class ClearLists
    {
        public void ClearAllLists(Lists lists)
        {
            while (true)
            {
                string answer;
                try
                {
                    Console.WriteLine("Clear existing lists? Y/N");
                    answer = Console.ReadLine();

                    if (answer is "N")
                        return ;
                    if (!(answer is "Y"))
                    {
                        throw new ArgumentException("Wrong input");
                    }
                    lists.AirCompanies.Clear();
                    lists.Helicopters.Clear();
                    lists.Planes.Clear();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                return ;
            }
        }
    }
}
