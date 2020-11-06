using System;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            // todo Nunit/Xunit
            var testsRunner = new Tests();
            testsRunner.Test1();
            testsRunner.Test2();
            testsRunner.Test3();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
