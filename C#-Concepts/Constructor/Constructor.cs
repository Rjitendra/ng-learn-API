
using System.Globalization;

namespace CSharpConcepts.Constructor
{
    public class Constructor
    {
        public static void Run()
        {
            Console.WriteLine("Country: " + Person.Country); // Static field access triggers Static Constructor

            // 1. Default Constructor
            Person defaultPerson = new Person();
            Console.WriteLine($"Default Person: {defaultPerson.Name}, {defaultPerson.Description}, Age: {defaultPerson.Age}");

            // 2. Parameterized Constructor (Full Properties)
            Person parameterizedPerson = new Person("John Doe", "Architect", "Male", new DateTime(1985, 5, 15), false);
            Console.WriteLine($"Parameterized Person: {parameterizedPerson.Name}, {parameterizedPerson.Description}, Age: {parameterizedPerson.Age}");

            // 3. Copy Constructor
            Person copiedPerson = new Person(parameterizedPerson);
            Console.WriteLine($"Copied Person: {copiedPerson.Name}, {copiedPerson.Description}, Age: {copiedPerson.Age}");

            // 4. Factory Method
            Person factoryPerson = Person.CreatePerson("Emily Smith", "Product Manager", "Female", "25/12/1992", true);
            Console.WriteLine($"Factory Method Person: {factoryPerson.Name}, {factoryPerson.Description}, Age: {factoryPerson.Age}");

            // 5. Singleton Instance (Private Constructor)
            Person singletonPerson = Person.GetSingletonInstance();
            Console.WriteLine($"Singleton Person: {singletonPerson.Name}, {singletonPerson.Description}");

            // 6. Expression-Bodied Constructor (Minimal Properties)
            Person minimalPerson = new Person("MinimalUser", "Non-Binary");
            Console.WriteLine($"Minimal Person: {minimalPerson.Name}, {minimalPerson.Gender}");

            Console.ReadLine();
        }
    }
    public class Person
    {
        // Static Field (shared across instances)
        public static string Country;

        // Instance Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public DateTime Dob { get; set; }
        public bool IsIndian { get; set; }
        public int Age { get; set; }

        // Singleton Instance (for demonstration)
        private static Person _singletonInstance;

        #region Static Constructor
        static Person()
        {
            Country = "India";
            Console.WriteLine("Static Constructor Called - Country Initialized");
        }
        #endregion

        #region Private Constructor (Singleton Pattern)
        private Person(bool initializeDefaults)
        {
            if (initializeDefaults)
            {
                Name = "Default Singleton";
                Description = "Singleton Instance";
                Gender = "Not Specified";
                Dob = DateTime.MinValue;
                IsIndian = true;
            }
        }

        public static Person GetSingletonInstance()
        {
            if (_singletonInstance == null)
            {
                _singletonInstance = new Person(true);
            }
            return _singletonInstance;
        }
        #endregion

        #region Default Constructor
        public Person()
        {
            Name = "Jitendra";
            Description = "Software Developer";
            Gender = "Male";
            Dob = DateTime.ParseExact("06/07/1990", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            IsIndian = true;
            Age = CalculateAge(Dob);
            Console.WriteLine("Default Constructor Called");
        }
        #endregion

        #region Parameterized Constructor (Full Properties)
        public Person(string name, string description, string gender, DateTime dob, bool isIndian)
        {
            Name = name;
            Description = description;
            Gender = gender;
            Dob = dob;
            IsIndian = isIndian;
            Age = CalculateAge(dob);
            Console.WriteLine("Parameterized Constructor Called");
        }
        #endregion

        #region Copy Constructor
        public Person(Person obj)
        {
            Name = obj.Name;
            Description = obj.Description;
            Gender = obj.Gender;
            Dob = obj.Dob;
            IsIndian = obj.IsIndian;
            Age = obj.Age;
            Console.WriteLine("Copy Constructor Called");
        }
        #endregion

        #region Factory Method (Alternative Object Creation)
        public static Person CreatePerson(string name, string description, string gender, string dobString, bool isIndian)
        {
            DateTime dob = DateTime.ParseExact(dobString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            return new Person(name, description, gender, dob, isIndian);
        }
        #endregion

        #region Expression-Bodied Constructor (Minimal Properties)
        public Person(string name, string gender) => (Name, Gender) = (name, gender);
        #endregion

        #region Helper Methods
        private int CalculateAge(DateTime dob)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age)) age--;
            return age;
        }
        #endregion
    }
}
