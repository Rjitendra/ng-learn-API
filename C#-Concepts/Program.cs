using CSharpConcepts.Constructor;
using CSharpConcepts.Delegates;
using CSharpConcepts.Generics;
using CSharpConcepts.Inheritance;

namespace Program
{
    class Program
    {

        static void Main()
        {
            while (true)
            {
                ShowMenu();

                Console.Write("\nEnter your choice: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("=== 🧩 Delegates Example ===\n");
                        Delegates.Run();
                        break;

                    case "2":
                        Console.WriteLine("=== 🧬 Generics Example ===\n");
                        Generic.Run();
                        break;
                    case "3":
                        Console.WriteLine("=== 🧬 Inheritance Example ===\n");
                        Inheritance.Run();
                        break;
                    case "4":
                        Console.WriteLine("=== 🧬 Constructor Example ===\n");
                        Constructor.Run();
                        break;
                    case "10":
                        clear();
                        break;
                    case "0":
                        Console.WriteLine("\n👋 Exiting...");
                        return;

                    default:
                        Console.WriteLine("\n❌ Invalid option. Try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to return to menu...");
                Console.ReadLine();
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("========== Main Menu ==========");
            Console.WriteLine("1 - Delegates Example");
            Console.WriteLine("2 - Generics Example");
            Console.WriteLine("3 - Inheritance Example");
            Console.WriteLine("4 - Constructor Example");
            Console.WriteLine("10 - Clear");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("================================");
        }

        static void clear()
        {
            Console.Clear();
        }
    }
}