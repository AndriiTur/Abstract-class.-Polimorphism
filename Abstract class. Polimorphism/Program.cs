using System;
using System.Collections.Generic;

namespace Abstract_class.Polimorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task7
            //string persName;
            //List<Person> newPeople = new List<Person>();

            //newPeople.Add(new Person("Vasia"));
            //newPeople.Add(new Staff("Kolia", 500));
            //newPeople.Add(new Teacher("Petia", 700));
            //newPeople.Add(new Developer("Ivan", 800));

            //foreach (Person pers in newPeople)
            //{
            //    pers.Print();
            //}

            //Console.Write("Enter person name: ");
            //persName = Console.ReadLine();
            //foreach (Person pers in newPeople)
            //{
            //    if (pers.Name == persName)
            //    {
            //        pers.Print();
            //    }
            //}

            //Console.ReadKey();
            #endregion

            #region HomeWork7
            double maxPerimetr = 0;
            Shape shapMaxPerim = new Circle("null", 0);
            List<Shape> myShapes = new List<Shape>();

            myShapes.Add(new Circle("C001", 10));
            myShapes.Add(new Circle("C002", 20));
            myShapes.Add(new Circle("C003", 30));
            myShapes.Add(new Circle("C004", 40));
            myShapes.Add(new Circle("C005", 50));
            myShapes.Add(new Square("S001", 10));
            myShapes.Add(new Square("S002", 20));
            myShapes.Add(new Square("S003", 30));
            myShapes.Add(new Square("S004", 40));
            myShapes.Add(new Square("S005", 50));

            foreach (Shape sh in myShapes)
            {
                Console.WriteLine($"Perimeter {sh.Name} = {sh.Perimeter()}");
                Console.WriteLine($"Area {sh.Name} = {sh.Area()}");
            }

            foreach (Shape sh in myShapes)
            {
                if (sh.Perimeter() > maxPerimetr)
                {
                    maxPerimetr = sh.Perimeter();
                    shapMaxPerim = sh;
                }
            }
            Console.WriteLine($"\nShape with Largest Perimeter {shapMaxPerim.Name} Perimeter = {shapMaxPerim.Perimeter()}");

            //myShapes.Sort();
            //foreach (Shape sh in myShapes)
            //{
            //    Console.WriteLine($"Area {sh.Name} = {sh.Area()}");
            //}

            Console.ReadKey();
            #endregion
        }
    }

    public abstract class Shape
    {
        string name;
        public string Name { get { return name; } set { name = value; } }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();

        public abstract double Perimeter();
    }

    public class Circle : Shape, IComparable
    {
        double radius;
        public double Radius { get; set; }

        public Circle(string name, double radius): base(name)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * this.radius;
        }

        public int CompareTo(object obj)
        {
            return Area().CompareTo(obj);
        }
    }

    public class Square : Shape, IComparable
    {
        double side;
        public double Side { get; set; }

        public Square(string name, double side) : base(name)
        {
            this.side = side;
        }
        public override double Area()
        {
            return this.side * this.side;
        }

        public override double Perimeter()
        {
            return this.side * 4;
        }

        public int CompareTo(object obj)
        {
            return Area().CompareTo(obj);
        }
    }

    #region Class for task
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
    #endregion
}
