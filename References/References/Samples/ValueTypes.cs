using System;

namespace References
{
    public static class ValueTypes
    {
        public static void RunSample()
        {
            var original = 0;

            Console.WriteLine($"Passing value type by value\t\t {original}");
            PassByValue(original);
            Console.WriteLine($"Changes visible to the Caller\t\t {original}\n");

            Console.WriteLine($"Passing value type by reference\t\t {original}");
            PassByReference(ref original);
            Console.WriteLine($"Changes visible to the Caller\t\t {original}\n");

            Console.ReadLine();
        }

        private static void PassByValue(int original)
        {
            Console.WriteLine($"(in-method) Variable passed by value\t {original}");

            original = 3;

            Console.WriteLine($"(in-method) Changed value\t\t {original}");
        }

        private static void PassByReference(ref int original)
        {
            Console.WriteLine($"(in-method) Variable passed by value\t {original}");

            original = 5;

            Console.WriteLine($"(in-method) Changed value\t\t {original}");
        }
    }
}
