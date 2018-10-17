using System;

namespace References
{
    public static class ReferenceTypes
    {
        public static void RunSample()
        {
            var original = new SimpleObject { Number = 2 };

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"Passing referece type by value: {original}\nMemory location: {**(IntPtr**)(&tr)}");
            }
            PassByValue(original);
            Console.WriteLine($"Changes visible to the Caller: {original}\n");

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"Passing referece type by reference: {original}\nMemory location: {**(IntPtr**)(&tr)}");
            }
            PassByReference(ref original);
            Console.WriteLine($"Changes visible to the Caller: {original}\n");

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"Reassigning referece type passed to a method by value: {original}\nMemory location: {**(IntPtr**)(&tr)}");
            }
            PassByValueAndReassign(original);
            Console.WriteLine($"Changes visible to the Caller: {original}\n");

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"Reassigning referece type passed to a method by reference: {original}\nMemory location: {**(IntPtr**)(&tr)}");
            }
            PassByReferenceAndReassign(ref original);
            Console.WriteLine($"Changes visible to the Caller: {original}\n");

            Console.WriteLine(@"Summary:
- Reference types are always passed by reference
- For referenc types ref keyword works as an alias to value containing address - any changes to original object (including reassigning) will affect both variables");
            Console.ReadLine();
        }

        private static unsafe void PassByValue(SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {original}");

            original.Number = 3;

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value: {original}");
            Console.WriteLine($"(in-method) Memory location: {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReference(ref SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {original}");

            original.Number = 5;

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value: {original}");
            Console.WriteLine($"(in-method) Memory location: {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByValueAndReassign(SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {original}");

            original = new SimpleObject();

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value: {original}");
            Console.WriteLine($"(in-method) Memory location: {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceAndReassign(ref SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {original}");

            original = new SimpleObject();

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value: {original}");
            Console.WriteLine($"(in-method) Memory location: {**(IntPtr**)(&tr)}");
        }

    }
}
