using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            String userInput;
            int number;

            Console.Out.WriteLine("Please type in equation to be solved");
            userInput = Console.In.ReadLine();
            userInput.Replace(" ", String.Empty);

            extractFirstSetOfNumbers(ref userInput);
            Console.In.Read();
        }

        /* Returns the first set of numbers encountered in a string
         * The string passed in must be passed in as reference to allow removal of extraced number
         * Argument string is assumed to have been checked beforehand to be starting with a number
         */
        public static int extractFirstSetOfNumbers(ref String substring)
        {
            int result = 0;
            int count = 0;
            String stringResult = "";
            foreach(char c in substring)
            {
                count++;
                if(isCharANumber(c))
                {
                    Console.Out.WriteLine(c);
                    stringResult = String.Concat(stringResult, c);
                }
                /*The purpose of this if is to end the search if we find a character that is not a number
                 * but only after we find a number to start with 
                 */
                else if (!stringResult.Equals(String.Empty))
                {
                    break;
                }
            }
            try 
            {
                result = Int32.Parse(stringResult);
                //Console.Out.WriteLine(count);
                stringResult = stringResult.Substring(count);
                Console.Out.WriteLine(result);
            }catch(Exception e)
            {
                Console.WriteLine("Error input string does not contain any numbers");
            }
            return result;
        }

        public static void determineEquationComponents(ref String equation)
        {
            do
            {
                int number = extractFirstSetOfNumbers(ref equation);
                Console.Out.WriteLine(number);
                Console.Out.WriteLine(equation);
                Console.In.ReadLine();
            } while(!equation.Equals(String.Empty));
        }

        public static Boolean isCharANumber(char c)
        {
            if(c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }
    }
}
