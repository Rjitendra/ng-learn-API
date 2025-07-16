using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Generics
{
    public class Generic
    {
        public static void Run()
        {
            DataStore<string> strStore = new DataStore<string>();
            strStore.Data = "Hello World!";
            Console.WriteLine(strStore.Data);
            //strStore.Data = 123; // compile-time error

            DataStore<int> intStore = new DataStore<int>();
            intStore.Data = 100;
            Console.WriteLine(intStore.Data);
            //intStore.Data = "Hello World!"; // compile-time error

            CustomKeyValuePair<int, string> kvp1 = new CustomKeyValuePair<int, string>();
            kvp1.Key = 100;
            kvp1.Value = "Hundred";
            Console.WriteLine(kvp1.Key + ", " + kvp1.Value);
            CustomKeyValuePair<string, string> kvp2 = new CustomKeyValuePair<string, string>();
            kvp2.Key = "IT";
            kvp2.Value = "Information Technology";
            Console.WriteLine(kvp2.Key + ", " + kvp2.Value);
        }
    }


    public class DataStore<T>
    {
        public T Data { get; set; }
    }
    // Example usage of GenericList with Employee objects
    public class CustomKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }


    }


}
// ==============================
// ✅ C# Generics – Complete Guide
// ==============================

#region 🔹 What Are Generics?
// Generics allow you to define classes, interfaces, methods, and delegates
// with a placeholder (type parameter) for the data type.
// ✅ Benefits:
// - Type Safety
// - Code Reusability
// - Performance (no boxing/unboxing)
// Example: List<T>, Dictionary<TKey, TValue>
#endregion

#region 🔹 1. Generic Class Example
// public class GenericBox<T>
// {
//     public T Value { get; set; }
//     
//     public void Display()
//     {
//         Console.WriteLine($"Value: {Value}");
//     }
// }

// // Usage:
// GenericBox<int> intBox = new GenericBox<int> { Value = 100 };
// intBox.Display();

// GenericBox<string> strBox = new GenericBox<string> { Value = "Hello" };
// strBox.Display();
#endregion

#region 🔹 2. Generic Method Example
// public class Utilities
// {
//     public void Print<T>(T item)
//     {
//         Console.WriteLine($"Item: {item}");
//     }
// }

// // Usage:
// Utilities utils = new Utilities();
// utils.Print<int>(10);
// utils.Print("Generic Method");
#endregion

#region 🔹 3. Generic with Constraints
// ✅ You can restrict types with where constraints.

// public class Repository<T> where T : class
// {
//     public void Add(T item)
//     {
//         Console.WriteLine($"Added: {item}");
//     }
// }

// // Usage:
// Repository<string> repo = new Repository<string>();
// repo.Add("Data");

// ⚠ Below would cause compile error since int is not a class:
// Repository<int> invalidRepo = new Repository<int>();
#endregion

#region 🔹 4. Multiple Type Parameters
// public class Pair<T1, T2>
// {
//     public T1 First { get; set; }
//     public T2 Second { get; set; }
// }

// // Usage:
// Pair<int, string> pair = new Pair<int, string> { First = 1, Second = "One" };
// Console.WriteLine($"{pair.First}, {pair.Second}");
#endregion

#region 🔹 5. Generic Interface
// public interface IProcessor<T>
// {
//     void Process(T input);
// }

// public class StringProcessor : IProcessor<string>
// {
//     public void Process(string input)
//     {
//         Console.WriteLine($"Processed string: {input}");
//     }
// }
#endregion

#region 🔹 6. Generic Delegate
// public delegate T Operation<T>(T a, T b);

// // Usage:
// Operation<int> add = (a, b) => a + b;
// int sum = add(3, 4);  // Output: 7

// Operation<string> concat = (a, b) => a + b;
// string result = concat("Hello, ", "World!");
#endregion

#region 🔹 7. Inheritance in Generics
// public class BaseEntity { }

// public class GenericRepo<T> where T : BaseEntity
// {
//     public void Save(T entity)
//     {
//         Console.WriteLine($"Saved: {entity}");
//     }
// }

// public class Product : BaseEntity
// {
//     public string Name { get; set; }
// }

// // Usage:
// GenericRepo<Product> productRepo = new GenericRepo<Product>();
// productRepo.Save(new Product { Name = "Laptop" });
#endregion

#region 🧠 Summary Table
// Feature                  | Example                                      | Description
//--------------------------|----------------------------------------------|-----------------------------
// Generic Class            | class Box<T> { ... }                         | Reusable class for any type
// Generic Method           | void Print<T>(T item)                        | Method with type parameter
// Constraint               | where T : class                              | Restrict type to reference types
// Multiple Type Params     | class Pair<T1, T2>                           | Use more than one generic type
// Generic Interface        | interface IProcessor<T>                      | Generic behavior definition
// Generic Delegate         | delegate T Operation<T>(T a, T b)            | Type-safe function pointer
// Inheritance in Generic   | where T : BaseEntity                         | Work with specific base types
#endregion
