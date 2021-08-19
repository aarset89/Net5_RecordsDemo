using System;

/*
 * Benefit of records:
 *   - Simple to set up
 *   - Thread-safe
 *   - ease/safe to share
 *  
 *  When to use records
 *   - capturing external data that doesn't change
 *   - Api calls
 *   - Processing data
 *  
 *  When NOT to use records
 *   - When you need to change data (Like entity framework) 
 
 
 */

namespace RecordDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new("Wila", "Sana");
            Record1 r1b = new("Wila", "Sana");
            Record1 r1c = new("Wilc", "Sanc");

            Class1 c1a = new("qweqwe", "Sana");
            Class1 c1b = new("qweqwe", "Sanb");
            Class1 c1c = new("qweqwe", "Sanc");


            Console.WriteLine($"Record: {r1a}");
            Console.WriteLine($"Are the r1a and r1b objects equal: {Equals(r1a, r1b)}");
            Console.WriteLine($"Are the r1a and r1b objects reference equal: {ReferenceEquals(r1a, r1b)}");
            Console.WriteLine($"Are two objects r1a == r1b {r1a == r1b}");
            Console.WriteLine($"Are two objects r1a != r1b {r1a != r1b}");
            Console.WriteLine($"Hash code of object A != {r1a.GetHashCode()}");
            Console.WriteLine($"Hash code of object B != {r1b.GetHashCode()}");
            Console.WriteLine($"Hash code of object C != {r1c.GetHashCode()}");
            Console.WriteLine($"*******************************");
            Console.WriteLine($"Class: {c1a}");
            Console.WriteLine($"Are the r1a and c1b objects equal: {Equals(c1a, c1b)}");
            Console.WriteLine($"Are the r1a and c1b objects reference equal: {ReferenceEquals(c1a, c1b)}");
            Console.WriteLine($"Are two objects c1a == c1b {c1a == c1b}");
            Console.WriteLine($"Are two objects c1a != c1b {c1a != c1b}");
            Console.WriteLine($"Hash code of object A != {c1a.GetHashCode()}");
            Console.WriteLine($"Hash code of object B != {c1b.GetHashCode()}");
            Console.WriteLine($"Hash code of object C != {c1c.GetHashCode()}");

            Console.WriteLine();

            //Deconstructor
            var (fn, ln) = r1a;

            Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");

            //Copy of data using Records
            Record1 r1d = r1a with
            {
                FirstName = "fran"
            };
            Console.WriteLine($"Fran's record {r1d}");

            Console.WriteLine();


            Record2 r2a = new("ale", "SM");
            Console.WriteLine($"r2a value is: {r2a}");
            Console.WriteLine($"r2a fn value is {r2a.FirstName}, r2a ln value is {r2a.LastName}");
            Console.WriteLine(r2a.SayHello());
        }
    }

    //A record is just a fancy class (A reference type of a class)
    //Inmutable (values Cannot be changes)
    public record User1(int id, string FirstName, string LastName) : Record1(FirstName, LastName);  //Inherit records and setting values
    public record Record1(string FirstName, string LastName);
    public record Record2(string FirstName, string LastName)
    {
        private string _firstName = FirstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init { }
        }

        //internal string FirstName { get; init; } = FirstName;
        public string Fullname { get => $"{FirstName} {LastName}"; }

        public string SayHello()
        {
            return $"Hi {FirstName}";
        }

    }

    public class asd
    {
        public User1 LookupUser { get; set; }

    }


    public class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
