using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PR2
{
    class PrintQuerie
    {
        public void Print<T>(IEnumerable<T> querie)
        {
            foreach(var x in querie)
            {
                Console.WriteLine("\n" + x.ToString());
            }
        }

        public void Print<T>(T answer)
        {
            Console.WriteLine(answer.ToString());
        }

        public void Print<T,Q>(Dictionary<T, List<Q>> querie)
        {
            foreach (var groupQuere in querie)
            {
                Console.WriteLine("\nKey = " + groupQuere.Key);
                foreach(var answer in groupQuere.Value)
                {
                    Console.WriteLine("\n" + answer.ToString());
                }
                
            }
        }

    }
}
