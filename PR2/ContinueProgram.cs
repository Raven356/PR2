using System;
using System.Collections.Generic;
using System.Text;

namespace PR2
{
    class ContinueProgram
    {
        public void Continue()
        {
            if (!IsExecutionContinuing())
                throw new ArgumentException("Good bye");
        }

        private bool IsExecutionContinuing()
        {
            while (true)
            {
                string answer;
                try
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    answer = Console.ReadLine();
                    Console.Clear();
                    if (!answer.Equals("N") && !answer.Equals("Y"))
                        throw new ArgumentException("Wrong input");
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                return answer.Equals("Y");
            }
        }
    }
}
