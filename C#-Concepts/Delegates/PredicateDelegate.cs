using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Delegates
{
    public class Product1
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    public class PredicateDelegate
    {
        public static void Run()
        {
            Console.WriteLine("Predicate Delegate");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Predicate Delegate - Example 1: Is Even");
            Console.WriteLine("----------------------------------------");
            // Predicate with int: Check if number is even
            Predicate<int> isEven = x => x % 2 == 0;
            Console.WriteLine(isEven(4)); // True
            Console.WriteLine(isEven(5)); // False


            Console.WriteLine("Predicate Delegate - Example 2: Is Null or Empty");
            Console.WriteLine("-----------------------------------------------");
            // Predicate with string: Check if string is null or empty
            Predicate<string> isNullOrEmpty = string.IsNullOrEmpty;
            Console.WriteLine(isNullOrEmpty(""));     // True
            Console.WriteLine(isNullOrEmpty("Hello")); // False


            Console.WriteLine("Predicate Delegate - Example 3: String Length > 5");
            Console.WriteLine("--------------------------------------------------");
            // Predicate with string: Check string length > 5
            Predicate<string> isLong = s => s.Length > 5;
            Console.WriteLine(isLong("Test"));     // False
            Console.WriteLine(isLong("Welcome"));  // True


            Console.WriteLine("Predicate Delegate - Example 4: List<T>.Find()");
            Console.WriteLine("---------------------------------------------");
            // Predicate with List<T>.Find()
            List<int> numbers = new() { 1, 3, 5, 6, 7, 8 };
            int firstEven = numbers.Find(isEven);
            Console.WriteLine(firstEven); // 6



            // Predicate with custom class
            Console.WriteLine("Predicate Delegate - Example 5: Custom Class");
            Console.WriteLine("-------------------------------------------");
            List<Product1> products = new()
                            {
                                new Product1 { Name = "Laptop", Price = 1000 },
                                new Product1 { Name = "Mouse", Price = 25 },
                                new Product1 { Name = "Keyboard", Price = 75 }
                            };

            // Predicate: Price > 500
            Predicate<Product1> isExpensive = p => p.Price > 500;
            Product1 expensiveProduct = products.Find(isExpensive);
            Console.WriteLine(expensiveProduct?.Name); // Laptop



            // Predicate with RemoveAll
            Console.WriteLine("Predicate Delegate - Example 6: RemoveAll");
            Console.WriteLine("-----------------------------------------");
            List<string> names = new() { "John", "", "Alice", "", "Bob" };
            names.RemoveAll(isNullOrEmpty);
            foreach (var name in names)
                Console.WriteLine(name); // John, Alice, Bob


            Console.WriteLine("Predicate Delegate - Example 7: Exists");
            Console.WriteLine("--------------------------------------");
            // Predicate with custom condition using List.Exists()
            bool hasCheapItem = products.Exists(p => p.Price < 50);
            Console.WriteLine(hasCheapItem); // True

        }
    }
}
// ================================================
// ✅ C# Predicate<T> Delegate – Full Documentation
// ================================================

#region 🔹 What is Predicate<T>?
// Predicate<T> is a built-in delegate in C#
// It represents a method that:
// - Takes one parameter of type T
// - Returns a bool (true/false)
//
// Syntax:
// Predicate<T> myPredicate = value => condition;
//
// Common Use Cases:
// - Filtering collections
// - Searching in collections
// - Removing elements from collections
#endregion

#region 🔸 Example 1: Predicate with int – Check if number is even
// Predicate<int> isEven = x => x % 2 == 0;
// Console.WriteLine(isEven(4));  // Output: True
// Console.WriteLine(isEven(5));  // Output: False
#endregion

#region 🔸 Example 2: Predicate with string – Check if null or empty
// Predicate<string> isNullOrEmpty = string.IsNullOrEmpty;
// Console.WriteLine(isNullOrEmpty(""));      // Output: True
// Console.WriteLine(isNullOrEmpty("Hello")); // Output: False
#endregion

#region 🔸 Example 3: Predicate with string – Check if length > 5
// Predicate<string> isLong = s => s.Length > 5;
// Console.WriteLine(isLong("Test"));     // Output: False
// Console.WriteLine(isLong("Welcome"));  // Output: True
#endregion

#region 🔸 Example 4: Use Predicate with List<T>.Find()
// List<int> numbers = new() { 1, 3, 5, 6, 7, 8 };
// int firstEven = numbers.Find(isEven);
// Console.WriteLine(firstEven); // Output: 6
#endregion

#region 🔸 Example 5: Predicate with custom class
// public class Product
// {
//     public string Name { get; set; }
//     public double Price { get; set; }
// }

// List<Product> products = new()
// {
//     new Product { Name = "Laptop", Price = 1000 },
//     new Product { Name = "Mouse", Price = 25 },
//     new Product { Name = "Keyboard", Price = 75 }
// };

// Predicate<Product> isExpensive = p => p.Price > 500;
// Product expensiveProduct = products.Find(isExpensive);
// Console.WriteLine(expensiveProduct?.Name); // Output: Laptop
#endregion

#region 🔸 Example 6: RemoveAll using Predicate
// List<string> names = new() { "John", "", "Alice", "", "Bob" };
// names.RemoveAll(isNullOrEmpty);
// foreach (var name in names)
//     Console.WriteLine(name); // Output: John, Alice, Bob
#endregion

#region 🔸 Example 7: Use Exists with Predicate
// bool hasCheapItem = products.Exists(p => p.Price < 50);
// Console.WriteLine(hasCheapItem); // Output: True
#endregion

#region 🧠 Summary Table
// Feature        | Example                                  | Description
//----------------|------------------------------------------|-----------------------------
// Basic Predicate| Predicate<int> isEven = x => x % 2 == 0; | Returns true/false
// List.Find      | list.Find(predicate)                     | Finds first matching element
// List.Exists    | list.Exists(predicate)                   | Checks if any match exists
// List.RemoveAll | list.RemoveAll(predicate)                | Removes matching elements
// Custom Class   | Predicate<Product>                       | Works with objects and conditions
#endregion