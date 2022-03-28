using System;

namespace Task2
{
    internal class Program
    {
        delegate int SomeDelegate();
        delegate int MainDelegate(SomeDelegate[] someDelegates);
        static void Main(string[] args)
        {
            SomeDelegate[] someDelegates = new SomeDelegate[50];

            Random rnd = new Random();
            for (int i = 0; i < someDelegates.Length; i++)
            {
                someDelegates[i] = rnd.Next;
            }

            MainDelegate aver = delegate(SomeDelegate[] someDelegates)
            {
                int sum = 0;

                foreach (var item in someDelegates)
                {
                    sum += item();
                }

                return sum / someDelegates.Length;
            };

            Console.WriteLine(aver(someDelegates));

            Console.ReadKey();
        }
    }
}
