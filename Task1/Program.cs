using System;

namespace Task1
{
    internal class Program
    {
        delegate int Average(int a, int b, int c);

        static void Main(string[] args)
        {
            Average average = delegate (int a, int b, int c)
            {
                return (a + b + c) / 3;
            };
            Console.WriteLine( average(87, 2, 9) );

            Console.ReadKey();
        }
    }
}
