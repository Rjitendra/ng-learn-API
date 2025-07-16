using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Delegates
{
    public class ActionDelegate
    {

        public void ExecuteAction(Action action)
        {
            Console.WriteLine("Before Action");
            action();
            Console.WriteLine("After Action");
        }
        public static void ExecuteAction<T>(T input, Action<T> action) // action is nothing a method 
        {
            Console.WriteLine("Before Action");
            action(input);
            Console.WriteLine("After Action");
        }
        static void RepeatAction(int times, Action<int> action)
        {
            for (int i = 0; i < times; i++)
            {
                action(i);
            }
        }

        public static void PrintMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }
        public static void PrintNumber(int number)
        {
            Console.WriteLine($"PrintNumber: {number}");
        }
        public void MyTask()
        {
            Console.WriteLine("Doing the actual work...");
        }


        public static void Run()
        {
            Console.WriteLine("Action Delegate");
            Console.WriteLine("----------------------------------------");
            // 1. Basic Action - No Parameters
            Action greet = () => Console.WriteLine("Hello, World!");
            greet();  // Output: Hello, World!

            // 2. Action with Parameters
            Action<string> printMessage = (message) => Console.WriteLine($"Message: {message}");
            printMessage("This is a test");

            Action<string> printMessage1 = PrintMessage;
            printMessage1("Hello from named method!");

            // 3. Action with Two Parameters
            Action<int, int> add = (a, b) => Console.WriteLine($"Sum: {a + b}");
            add(5, 3);  // Output: Sum: 8

            // 4. Passing Action as a Method Parameter
            // Create an instance of ActionDelegate to call the non-static method
            var actionDelegate = new ActionDelegate();
            actionDelegate.ExecuteAction(() => Console.WriteLine("Action logic running"));
            actionDelegate.ExecuteAction(actionDelegate.MyTask);
            ExecuteAction(10, x => Console.WriteLine($"Square: {x * x}"));
            //5. Action with Custom Logic and Variables

            RepeatAction(3, i => Console.WriteLine($"Iteration {i}"));
            RepeatAction(3, PrintNumber);
            // Output:
            // Iteration 0
            // Iteration 1
            // Iteration 2

            // 6. Multicast Action
            Action multiAction = () => Console.WriteLine("First");
            multiAction += () => Console.WriteLine("Second");

            multiAction();
            // Output:
            // First
            // Second

            // 7.Action in a Class Context
            // Usage
            var runner = new TaskRunner { Task = () => Console.WriteLine("Task executed") };
            // Example 2: Using RepeatAction
            TaskRunner.RepeatAction(3, i => Console.WriteLine($"Iteration {i}"));
            runner.Run();
        }
    }

    public class TaskRunner
    {
        public Action Task { get; set; }

        // Change the access modifier of RepeatAction from private to public
        public static void RepeatAction(int times, Action<int> action)
        {
            for (int i = 0; i < times; i++)
            {
                action(i);
            }
        }

        public void Run()
        {
            Console.WriteLine("Running task...");
            Task?.Invoke();
        }
    }
}
