using System;
using System.Collections.Generic;

namespace Abstract_class.Polimorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task7
            string persName;
            List<Person> newPeople = new List<Person>();

            newPeople.Add(new Person("Vasia"));
            newPeople.Add(new Staff("Kolia", 500));
            newPeople.Add(new Teacher("Petia", 700));
            newPeople.Add(new Developer("Ivan", 800));

            foreach (Person pers in newPeople)
            {
                pers.Print();
            }

            Console.Write("Enter person name: ");
            persName = Console.ReadLine();
            foreach (Person pers in newPeople)
            {
                if (pers.Name == persName)
                {
                    pers.Print();
                }
            }

            Console.ReadKey();
            #endregion
        }
    }

    public class Person
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }
        virtual public string Name { get { return name; } }
        virtual public void Print()
        {
            Console.WriteLine("Name: {0}", this.name);
        }
    }

    public class Staff : Person
    {
        private int salary;
        private string name;

        public Staff(string name): base(name)
        {
            this.name = name;
        }

        public Staff(string name, int salary) : base(name)
        {
            this.salary = salary;
        }
        override public string Name
        {
            get
            {
                return base.Name;
            }
        }
        override public void Print()
        {
            Console.WriteLine("Person {0} has salary: ${1}", Name, this.salary);
        }
    }

    public class Teacher : Staff
    {
        string subject;
        int salary;
        public Teacher(string name, int salary) : base(name)
        {
            this.salary = salary;
        }

        override public void Print()
        {
            Console.WriteLine("Teacher {0} has salary: ${1}", Name, this.salary);
        }
    }

    public class Developer : Staff
    {
        string level;
        int salary;
        public Developer(string name, int salary) : base(name)
        {
            this.salary = salary;
        }

        override public void Print()
        {
            Console.WriteLine("Developer {0} has salary: ${1}", Name, this.salary);
        }
    }
}
