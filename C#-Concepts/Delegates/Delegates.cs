

namespace CSharpConcepts.Delegates
{
    // Delegate with no parameters
    public delegate void Print();

    // Delegate with two int parameters
    public delegate void Add(int a, int b);
    public class Delegates
    {// Method that matches the 'Add' delegate signature
        public void add(int a, int b)
        {
            Console.WriteLine($"Sum: {a + b}");
        }

        // Method that matches the 'Print' delegate signature
        public void PrintMessage()
        {
            Console.WriteLine("Hello from Print delegate!");
        }
        public static void Run()
        {
            Delegates obj = new Delegates();
            obj.add(5, 10); // Call add method 
            Add dl = obj.add; // Create delegate instance
                              // Assign method to delegate
                              // Add addDelegate = new Add(obj.AddNumbers);
            dl(5, 10); // Invoke delegate

            Print printDelegate = new Print(obj.PrintMessage);
            printDelegate();      // Output: Hello from Print delegate!

            // 1.Basic Action - No Parameters
            Action greet = () => Console.WriteLine("Hello, World!");
            greet();  // Output: Hello, World!

            ActionDelegate.Run(); // Call ActionDelegate Run method
            FuncDelegate.Run(); // Call FuncGenerics Run method
            PredicateDelegate.Run(); // Call PredicateDelegate Run method


        }
    }
}


// ==============================
// ✅ C# Delegates – Complete Guide
// ==============================

#region 🔹 What Are Delegates?
// A delegate is a type-safe function pointer — it holds a reference to a method
// with a specific signature and return type.
#endregion

#region 🔹 Types of Delegates
// Delegate Type     | Description                                | Returns  | Parameters
// ------------------|--------------------------------------------|----------|------------
// Custom delegate   | User-defined method signature               | Custom   | Custom
// Action            | Built-in delegate for void-returning methods| void     | 0 to 16
// Func              | Built-in delegate returning a value         | Any      | 0 to 16
// Predicate<T>      | Returns a bool                              | bool     | 1
// Multicast         | Combine multiple methods                    | void     | N/A
#endregion

#region 🔹 1. Custom Delegate Example
// public delegate void MyDelegate(string name);

// void Greet(string name)
// {
//     Console.WriteLine($"Hello, {name}!");
// }

// // Usage:
// MyDelegate d = Greet;
// d("John");
#endregion

#region 🔹 2. Action Delegate Example
// ✅ Action: returns void, takes 0 to 16 parameters

// Action sayHello = () => Console.WriteLine("Hello!");
// sayHello();

// Action<int, int> add = (a, b) => Console.WriteLine(a + b);
// add(5, 3);
#endregion

#region 🔹 3. Func Delegate Example
// ✅ Func: Last type argument is the return type

// Func<int, int, int> multiply = (a, b) => a * b;
// int result = multiply(4, 5);
// Console.WriteLine($"Result: {result}");
#endregion

#region 🔹 4. Predicate Delegate Example
// ✅ Predicate: Takes one input, returns bool

// Predicate<int> isEven = x => x % 2 == 0;

// Console.WriteLine(isEven(10));  // Output: True
// Console.WriteLine(isEven(7));   // Output: False
#endregion

#region 🔹 5. Multicast Delegate Example
// ✅ One delegate instance can reference multiple methods

// public delegate void Notify();

// void MethodA() => Console.WriteLine("A called");
// void MethodB() => Console.WriteLine("B called");

// // Usage:
// Notify notify = MethodA;
// notify += MethodB;

// notify(); 
// Output:
// A called
// B called

// ⚠ If return values are involved, only the last method’s return value is returned.
#endregion

#region 🔁 Using Delegates as Parameters
// ✅ Passing a delegate as a method parameter

// void Execute(Action task)
// {
//     Console.WriteLine("Before task");
//     task();
//     Console.WriteLine("After task");
// }

// // Usage:
// Execute(() => Console.WriteLine("Running..."));
#endregion

#region 🧠 Summary Table
// Type           | Signature Example                                | Description
// ---------------|--------------------------------------------------|-----------------------------
// delegate       | delegate void MyDelegate(string name)            | Custom user-defined delegate
// Action         | Action<int> log = x => ...                       | Void-returning method
// Func           | Func<int, int, int> add = (x, y) => ...          | Returns a value
// Predicate<T>   | Predicate<string> isLong = s => ...              | Returns a bool
// Multicast      | notify += AnotherMethod                          | Invokes multiple methods
#endregion