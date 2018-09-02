using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppGrammar
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    List<string> fruits = new List<string> { "apple", "passionfruit", "banana", "mango", "orange", "blueberry", "grape", "strawberry" };
        //    //List<string> query = fruits.Where(fruit => fruit.Length < 6).ToList();
        //    IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);
        //    foreach (string fruit in query)
        //        Console.WriteLine(fruit);

        //    Console.Read();
        //}

        #region Lambda运算符
        //static void Main(string[] args)
        //{
        //    //Lambda运算符
        //    string[] words = { "cherry", "apple", "blueberry" };

        //    // Use method syntax to apply a lambda expression to each element  
        //    // of the words array.   
        //    //int shortestWordLength = words.Min(w => w.Length);
        //    //Console.WriteLine(shortestWordLength);

        //    var query = from w in words
        //                select w.Length;
        //    // Apply the Min method to execute the query and get the shortest length.  
        //    int shortestWordLength2 = query.Min();
        //    Console.WriteLine(shortestWordLength2);

        //    Console.Read();
        //}
        #endregion

        static void Main(string[] args)
        {

            string[] digits = { "zero", "one", "two", "three", "four", "five",
            "six", "seven", "eight", "nine" };

            Console.WriteLine("Example that uses a lambda expression:");
            var shortDigits = digits.Where((digit, index) => digit.Length < index);
            foreach (var sD in shortDigits)
            {
                Console.WriteLine(sD);
            }
            Console.Read();
        }
    }
}
