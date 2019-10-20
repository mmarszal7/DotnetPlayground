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
                Console.Write($"Passing referece type by value:\t\t\t\t {original}\nMemory location:\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            Console.ReadLine();
            PassByValue(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t {original}\n");

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.Write($"Passing referece type by reference:\t\t\t {original}\nMemory location:\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            Console.ReadLine();
            PassByReference(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t {original}\n");

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.Write($"Reassigning referece type passed to a method by value:\t {original}\nMemory location:\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            Console.ReadLine();
            PassByValueAndReassign(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t {original}\n");

            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.Write($"Reassigning referece type passed to a method by reference: {original}\nMemory location:\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            Console.ReadLine();
            PassByReferenceAndReassign(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t {original}\n");

            Console.WriteLine(@"Summary:
- Reference types are always passed by reference
- For reference types ref keyword works as an alias to value containing address - any changes to original object (including reassigning) will affect both variables");
            Console.ReadLine();
        }

        private static unsafe void PassByValue(SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t {original}");

            original.Number = 3;

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t {original}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReference(ref SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t {original}");

            original.Number = 5;

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t {original}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByValueAndReassign(SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t {original}");

            original = new SimpleObject();

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t {original}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceAndReassign(ref SimpleObject original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t {original}");

            original = new SimpleObject();

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t {original}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t {**(IntPtr**)(&tr)}");
        }

    }
}
