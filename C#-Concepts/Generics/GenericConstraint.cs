using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.Generics
{
    // IEntity defines a contract for all entities — each must have an integer Id.
    public interface IEntity
    {
        int Id { get; set; }
    }

    // Employee class implements IEntity, meaning it must have an Id property.
    public class Employee : IEntity
    {
        public int Id { get; set; }            // Unique identifier for the employee
        public string Name { get; set; } = ""; // Name of the employee

        // Override ToString() to provide a readable string representation of the object.
        public override string ToString() => $"Employee: {Name} (ID: {Id})";
    }

    // Product class also implements IEntity and thus must have an Id property.
    public class Product : IEntity
    {
        public int Id { get; set; }              // Unique identifier for the product
        public string Title { get; set; } = "";  // Title or name of the product

        // Override ToString() for human-readable output
        public override string ToString() => $"Product: {Title} (ID: {Id})";
    }

    // Generic Repository class that works with any type T that is:
    // - a class (reference type)
    // - implements IEntity (i.e., has an Id)
    // - has a parameterless constructor (new())
    public class Repository<T> where T : class, IEntity, new()
    {
        // CreateNew method creates and returns a new instance of T
        // Only allowed because of the 'new()' constraint
        public T CreateNew()
        {
            return new T(); // Creates an empty instance of T
        }

        // Internal list to hold data of type T
        private readonly List<T> _data = new();

        // Event triggered when an item is added to the repository
        public event Action<T>? OnItemAdded;

        // Adds a new item to the repository and triggers the event
        public void Add(T item)
        {
            _data.Add(item);             // Store in list
            OnItemAdded?.Invoke(item);   // Notify subscribers if any
        }

        // Searches the repository for an item with a matching Id
        public T? GetById(int id) => _data.FirstOrDefault(x => x.Id == id);

        // Returns all items or filtered items using a predicate (e.g., lambda expression)
        public IEnumerable<T> GetAll(Func<T, bool>? predicate = null)
        {
            // If a filter is provided, return matching items, else return all
            return predicate != null ? _data.Where(predicate) : _data;
        }

        // Removes an item from the repository based on its Id
        public void Delete(int id)
        {
            var item = GetById(id);    // Locate item
            if (item != null)          // If found, remove it
                _data.Remove(item);
        }

        // Print all items in the repository to the console
        public void PrintAll()
        {
            foreach (var item in _data)
            {
                Console.WriteLine(item);  // Calls overridden ToString() method
            }
        }
    }

    // A placeholder class (currently unused)
    // Could be used for testing constraints or grouping generic logic
    public class GenericConstraint
    {
        public static void Run()
        { // generics constrints
            var employeeRepo = new Repository<Employee>();
            var productRepo = new Repository<Product>();

            // Subscribe to event
            employeeRepo.OnItemAdded += e => Console.WriteLine($"[Event] New employee added: {e.Name}");
            productRepo.OnItemAdded += e => Console.WriteLine($"[Event] New product added: {e.Title}");

            // Add Employees
            employeeRepo.Add(new Employee { Id = 1, Name = "Alice" });
            employeeRepo.Add(new Employee { Id = 2, Name = "Bob" });

            // Add Products
            productRepo.Add(new Product { Id = 100, Title = "Laptop" });
            productRepo.Add(new Product { Id = 200, Title = "Phone" });

            Console.WriteLine("\nEmployees:");
            employeeRepo.PrintAll();

            Console.WriteLine("\nProducts:");
            productRepo.PrintAll();

            // Lambda filter
            Console.WriteLine("\nFiltered Employees (Id > 1):");
            var filtered = employeeRepo.GetAll(e => e.Id > 1);
            foreach (var emp in filtered)
                Console.WriteLine(emp);
        }
    }
}