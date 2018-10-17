using System;
using System.Collections.Generic;
using System.Linq;

namespace References
{
    public static class ListOfValueTypes
    {
        public static void RunSample()
        {

            // Update Item
            var original = new List<int> { 1, 2, 3 };
            Console.WriteLine($"(Update Item) Passing list of referece types by value: {String.Join(", ", original)}");
            PassByValueAndUpdateItem(original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            Console.WriteLine($"(Update Item) Passing list of referece types by reference: {String.Join(", ", original)}");
            PassByReferenceUpdateItem(ref original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            // Reassign collection
            original = new List<int> { 1, 2, 3 };
            Console.WriteLine($"(Reassign collection) Passing list of reference type by value: {String.Join(", ", original)}");
            PassByValueAndReassign(original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            Console.WriteLine($"(Reassign collection) Passing list of reference type by reference: {String.Join(", ", original)}");
            PassByReferenceAndReassign(ref original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            // Replace item
            original = new List<int> { 1, 2, 3 };
            Console.WriteLine($"(Replace item) Passing list of reference type by value: {String.Join(", ", original)}");
            PassByValueAndReplaceItem(original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            Console.WriteLine($"(Replace item) Passing list of reference type by reference: {String.Join(", ", original)}");
            PassByReferenceAndReplaceItem(ref original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            // Append item
            original = new List<int> { 1, 2, 3 };
            Console.WriteLine($"(Append item) Passing list of reference type by value: {String.Join(", ", original)}");
            PassByValueAndAppendItem(original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            Console.WriteLine($"(Append item) Passing list of reference type by reference: {String.Join(", ", original)}");
            PassByReferenceAndAppendItem(ref original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            // Delete item
            original = new List<int> { 1, 2, 3 };
            Console.WriteLine($"(Delete item) Passing list of reference type by value: {String.Join(", ", original)}");
            PassByValueAndDeleteItem(original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            Console.WriteLine($"(Delete item) Passing list of reference type by reference: {String.Join(", ", original)}");
            PassByReferenceAndDeleteItem(ref original);
            Console.WriteLine($"Changes visible to the Caller: {String.Join(", ", original)}\n");

            Console.WriteLine(@"Summary:");
            Console.ReadLine();
        }

        // Update item
        private static void PassByValueAndUpdateItem(List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original[0] = 10;

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        private static void PassByReferenceUpdateItem(ref List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original[0] = 10;

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        // Reassign
        private static void PassByValueAndReassign(List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original = new List<int>();

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        private static void PassByReferenceAndReassign(ref List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original = new List<int>();

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        // Append
        private static void PassByValueAndAppendItem(List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original.Add(10);

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        private static void PassByReferenceAndAppendItem(ref List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original.Add(10);

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        // Delete
        private static void PassByValueAndDeleteItem(List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original.RemoveAt(0);

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        private static void PassByReferenceAndDeleteItem(ref List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            original.RemoveAt(0);

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        // Replace
        private static void PassByValueAndReplaceItem(List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            if (original.Any())
                original[0] = 10;

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }

        private static void PassByReferenceAndReplaceItem(ref List<int> original)
        {
            Console.WriteLine($"(in-method) Variable passed by value: {String.Join(", ", original)}");

            if (original.Any())
                original[0] = 10;

            Console.WriteLine($"(in-method) Changed value: {String.Join(", ", original)}");
        }
    }
}
