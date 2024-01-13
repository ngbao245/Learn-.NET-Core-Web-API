using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.ExtensionMethod
{
    //This is call extension method
    public static class StudentExtensionsMethod
    {
        public static void PrintInfo(this Student student)
        {
            Console.WriteLine($"Info: {student.Name} {student.Age}");
        }
    }
}
