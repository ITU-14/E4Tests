using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Add("1,-2\n3,-5"));
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            

            Console.ReadKey();
        }

        /*
         * Time and Space complexity: O(n) where n is the length of the inputNumbers String.
         */
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers)) return 0;
            
            numbers = HandleDelimiters(numbers, out char delimiter);

            numbers = numbers.Replace('\n', delimiter);

            // in case we have the inputNumbers as follows "1,\n", I assume we can trim the \n with the comma then we can have 1 as a result.
            // but if we have the inputNumbers as follows "1,\n3,5", I assume we have an exception saying input error.

            for(var k = 0; k < numbers.Length-1;k ++)
            {
                if (numbers[k] == numbers[k + 1] && numbers[k] == delimiter) throw new Exception("input error!");
            }

            var nums = numbers.Split(delimiter);

            var exceptionNumbers = string.Empty;

            var result = 0;

            int num;

            foreach (var numberString in nums)
            {
                if (int.TryParse(numberString, out num) && num < 0) {
                    exceptionNumbers = string.Concat(exceptionNumbers, num, ",");

                    continue;
                }

                result += num;
            }

            if (!string.IsNullOrEmpty(exceptionNumbers)) throw new Exception($"negatives not allowed [{exceptionNumbers.TrimEnd(',')}]");

            return result;
        }

        static string HandleDelimiters(string numbers, out char delimiter)
        {
            if (!numbers.StartsWith("//")) {
                delimiter = ',';
                return numbers;
            }

            delimiter = numbers[2];

            return numbers.Substring(4);
        }
    }
}
