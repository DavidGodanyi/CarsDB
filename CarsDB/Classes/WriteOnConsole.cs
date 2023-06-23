using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CarsDB.Classes
{
    static class WriteOnConsole
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string header)
        {
            Console.WriteLine("***" + header + "***");
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("***" + header + "***");
            Console.ReadLine();
        }
    }
}
