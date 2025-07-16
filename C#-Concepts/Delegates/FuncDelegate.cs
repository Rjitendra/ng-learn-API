using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Delegates
{
    public class FuncDelegate
    {
        public static void Run()
        {
            Console.WriteLine("Func Delegate");
            Console.WriteLine("----------------------------------------");

            // Func with no parameters
            Func<string> greet = () => "Hello World!";
            Console.WriteLine(greet());

            // Func with one parameter
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(5));

            // Func with two parameters
            Func<int, int, int> add = (a, b) => a + b;
            int result = add(10, 20);
            Console.WriteLine(result);

            // Func with three parameters
            Func<int, int, int, double> average = (a, b, c) => (a + b + c) / 3.0;
            Console.WriteLine(average(10, 20, 30));

            // Func returning bool
            Func<string, bool> isLongString = s => s.Length > 5;
            Console.WriteLine(isLongString("Hello"));
            Console.WriteLine(isLongString("Welcome"));

            // Func as method parameter
            void Execute(Func<int, int, int> operation, int x, int y)
            {
                int result = operation(x, y);
                Console.WriteLine(result);
            }
            Execute((a, b) => a * b, 3, 4);

            // Func with LINQ
            string[] names = { "John", "Bob", "Alice", "Jennifer" };
            Func<string, bool> startsWithJ = name => name.StartsWith("J");
            var jNames = names.Where(startsWithJ);
            foreach (var name in jNames)
                Console.WriteLine(name);

            List<Person> people = new List<Person>
                                    {
                                        new Person { Name = "Alice", Age = 25 },
                                        new Person { Name = "Bob", Age = 30 },
                                        new Person { Name = "Charlie", Age = 20 }
                                    };
            Func<Person, string> getName = p => p.Name;
            foreach (var person in people)
                Console.WriteLine(getName(person));

            // Nested Func
            Func<int, Func<int, int>> multiplier = x => (y => x * y);
            var timesTwo = multiplier(2);
            Console.WriteLine(timesTwo(5));
            var timesTen = multiplier(10);
            Console.WriteLine(timesTen(3));

            // Func stored in dictionary
            Dictionary<string, Func<int, int, int>> operations = new()
                            {
                                { "add", (a, b) => a + b },
                                { "sub", (a, b) => a - b },
                                { "mul", (a, b) => a * b },
                                { "div", (a, b) => b != 0 ? a / b : 0 }
                            };
            int x = 20, y = 5;
            Console.WriteLine(operations["add"](x, y));
            Console.WriteLine(operations["sub"](x, y));
            Console.WriteLine(operations["mul"](x, y));
            Console.WriteLine(operations["div"](x, y));
        }
    }
}
// Func with custom class
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


// =============================================
// ✅ C# Func Delegate – Simple to Advanced Guide
// =============================================

#region 🔹 What is Func?
// ✅ Func is a built-in delegate in C#
// ✅ It represents a method that returns a value.
// ✅ It can take 0 to 16 input parameters.
// ✅ The last type parameter is the return type.

// Syntax:
// Func<in T1, ..., out TResult>

// Example:
// Func<int, int, int> --> Takes 2 int parameters, returns an int
#endregion

#region 🔸 Example 1: Func with No Parameters
// Func<string> greet = () => "Hello World!";
// Console.WriteLine(greet()); // Output: Hello World!
#endregion

#region 🔸 Example 2: Func with One Parameter
// Func<int, int> square = x => x * x;
// Console.WriteLine(square(5)); // Output: 25
#endregion

#region 🔸 Example 3: Func with Two Parameters
// Func<int, int, int> add = (a, b) => a + b;
// int result = add(10, 20);
// Console.WriteLine($"Sum: {result}"); // Output: Sum: 30
#endregion

#region 🔸 Example 4: Func with Three Parameters
// Func<int, int, int, double> average = (a, b, c) => (a + b + c) / 3.0;
// Console.WriteLine($"Average: {average(10, 20, 30)}"); // Output: Average: 20
#endregion

#region 🔸 Example 5: Func with Custom Logic
// Func<string, bool> isLongString = s => s.Length > 5;
// Console.WriteLine(isLongString("Hello"));    // Output: False
// Console.WriteLine(isLongString("Welcome"));  // Output: True
#endregion

#region 🔸 Example 6: Func as Method Parameter
// void Execute(Func<int, int, int> operation, int x, int y)
// {
//     int result = operation(x, y);
//     Console.WriteLine($"Result: {result}");
// }

// // Usage:
// Execute((a, b) => a * b, 3, 4); // Output: Result: 12
#endregion

#region 🔸 Example 7: Func with LINQ
// string[] names = { "John", "Bob", "Alice", "Jennifer" };

// // Using Func<string, bool> as a filter
// Func<string, bool> startsWithJ = name => name.StartsWith("J");

// var jNames = names.Where(startsWithJ);
// foreach (var name in jNames)
//     Console.WriteLine(name); // Output: John, Jennifer
#endregion

#region 🔸 Example 8: Func with Custom Class
// public class Person
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
// }

// List<Person> people = new List<Person>
// {
//     new Person { Name = "Alice", Age = 25 },
//     new Person { Name = "Bob", Age = 30 },
//     new Person { Name = "Charlie", Age = 20 }
// };

// // Func<Person, string> to select Name
// Func<Person, string> getName = p => p.Name;

// foreach (var person in people)
//     Console.WriteLine(getName(person)); // Output: Alice, Bob, Charlie
#endregion

#region 🔸 Example 9: Nested Func
// Func<int, Func<int, int>> multiplier = x => (y => x * y);

// var timesTwo = multiplier(2);
// Console.WriteLine(timesTwo(5)); // Output: 10

// var timesTen = multiplier(10);
// Console.WriteLine(timesTen(3)); // Output: 30
#endregion

#region 🔸 Example 10: Func in Dictionary
// Dictionary<string, Func<int, int, int>> operations = new()
// {
//     { "add", (a, b) => a + b },
//     { "sub", (a, b) => a - b },
//     { "mul", (a, b) => a * b },
//     { "div", (a, b) => b != 0 ? a / b : 0 }
// };

// int x = 20, y = 5;
// Console.WriteLine($"Add: {operations["add"](x, y)}"); // Output: 25
// Console.WriteLine($"Sub: {operations["sub"](x, y)}"); // Output: 15
#endregion

#region 🧠 Summary – Func Delegate
// ✅ Use Func<T> when:
// - You want to pass methods/functions that return values.
// - You want inline logic for filtering, transforming, or computing values.

// ✅ Func is widely used in:
// - LINQ (Where, Select, Aggregate, etc.)
// - Callbacks
// - Custom logic passing
#endregion
