using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.ExtensionMethod
{
    public class Student
    {
        public string? Name { get; set; }
        public int? Age { get; set; }

        public void SayHello()
        {
            if (Name != null || Age != null)
            {
                Console.WriteLine($"Hello, My Name is {Name}, I'm {Age}.");
            }
            else
            {
                Console.WriteLine("Hello World!");

            }
        }
    }
}
