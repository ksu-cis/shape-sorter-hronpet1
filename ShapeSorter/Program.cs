using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapeSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fun With Shapes!");

            List<IShape> shapes = new List<IShape>()
            {
                new Circle(4.0),
                new Rectangle(6,7),
                new Square(5.0),
                new Circle(2.5),
                new Rectangle(2.0,4.0),
                new Circle(3.0),
                new Square(10)
            };

            foreach (IShape shape in shapes)
            {
                Console.WriteLine($"Area of shape is {shape.Area}\n");
            }

            Console.WriteLine("---------------");

            IEnumerable<IShape> filteredShapes = shapes.Where(shape => shape.Area > 50);

            foreach (IShape shape in filteredShapes)
            {
                Console.WriteLine($"Area of shapes with area bigger than 50 is {shape.Area}\n");
            }

            Console.WriteLine("---------------");

            IEnumerable<Circle> circles;

            circles = shapes.OfType<Circle>();

            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Area of circle is {shape.Area} and it's radius is {shape.Radius}\n");
            }

            Console.WriteLine("---------------");

            circles = circles.Where(circle => circle.Area < 30);

            foreach (Circle shape in circles)
            {
                Console.WriteLine($"Circle has area below 30 ({shape.Area}) and it's radius is {shape.Radius}\n");
            }

            Console.WriteLine("---------------");

            Console.WriteLine("Grouping by area");
            var groupByArea = shapes.GroupBy(shape => shape.Area % 2 == 0);
            foreach(var group in groupByArea)
            {
                Console.WriteLine(group.Key ? "Evens" : "Odds");
                foreach(var shape in group)
                {
                    Console.WriteLine($"Shape with area {shape.Area}");
                }
            }


            Console.WriteLine("---------------");


            Console.WriteLine("Grouping by type");

            var groupByType = shapes.GroupBy(shape => shape.GetType());
            foreach (var group in groupByType)
            {
                Console.WriteLine(group.Key.Name);
                foreach (var shape in group)
                {
                    Console.WriteLine($"{group.Key.Name} with area {shape.Area}");
                }
            }



            Console.ReadLine();
        }
    }
}
