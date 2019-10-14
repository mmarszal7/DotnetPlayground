using System;
using System.Collections.Generic;
using System.Linq;

namespace References
{
    public static class ListOfReferenceTypes
    {
        public static void RunSample()
        {

            // Update Item
            var original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Update Item) Passing list of reference type by value:\t\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByValueAndUpdateItem(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Update Item) Passing list of reference type by reference:\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByReferenceUpdateItem(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            // Replace item
            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Replace item) Passing list of reference type by value:\t\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByValueAndReplaceItem(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Replace item) Passing list of reference type by reference:\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByReferenceAndReplaceItem(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            // Append item
            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Append item) Passing list of reference type by value:\t\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByValueAndAppendItem(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Append item) Passing list of reference type by reference:\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByReferenceAndAppendItem(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            // Delete item
            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Delete item) Passing list of reference type by value:\t\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByValueAndDeleteItem(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Delete item) Passing list of reference type by reference:\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByReferenceAndDeleteItem(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            // Reassign collection
            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Reassign) Passing list of reference type by value:\t\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByValueAndReassign(original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}\n");

            original = new List<SimpleObject> { new SimpleObject { Number = 1 }, new SimpleObject { Number = 2 }, new SimpleObject { Number = 3 } };
            unsafe
            {
                TypedReference tr = __makeref(original);
                Console.WriteLine($"(Reassign) Passing list of reference type by reference:\t\t\t {String.Join(", ", original)}\nMemory location:\t\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
            }
            PassByReferenceAndReassign(ref original);
            Console.WriteLine($"Changes visible to the Caller:\t\t\t\t\t\t {string.Join(", ", original.Select(o => o.Number))}-\n");

            Console.WriteLine(@"Summary:");
            Console.ReadLine();
        }

        // Update item
        private static unsafe void PassByValueAndUpdateItem(List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original[0].Number = 10;

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceUpdateItem(ref List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original[0].Number = 10;

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        // Reassign
        private static unsafe void PassByValueAndReassign(List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original = new List<SimpleObject>();

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}-");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceAndReassign(ref List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original = new List<SimpleObject>();

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}-");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        // Append
        private static unsafe void PassByValueAndAppendItem(List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original.Add(new SimpleObject() { Number = 10 });

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceAndAppendItem(ref List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original.Add(new SimpleObject() { Number = 10 });

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        // Delete
        private static unsafe void PassByValueAndDeleteItem(List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original.RemoveAt(0);

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceAndDeleteItem(ref List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original.RemoveAt(0);

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        // Replace
        private static unsafe void PassByValueAndReplaceItem(List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original[0] = new SimpleObject { Number = 10 };

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }

        private static unsafe void PassByReferenceAndReplaceItem(ref List<SimpleObject> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value:\t\t\t\t\t {String.Join(", ", original)}");

            original[0] = new SimpleObject { Number = 10 };

            TypedReference tr = __makeref(original);
            Console.WriteLine($"(in-method) Changed value:\t\t\t\t\t\t {String.Join(", ", original.Select(o => o.Number))}");
            Console.WriteLine($"(in-method) Memory location:\t\t\t\t\t\t {**(IntPtr**)(&tr)}");
        }
    }
}
