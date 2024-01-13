using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.LambdaExpression
{
    public static class AnonymousMethod
    {
        public delegate string Bill1(int money);
        // Example 1
        public static void PrintBill1()
        {
            Bill1 bill = delegate (int money)
            {
                return $"Ex1: You spend {money}$ for food.";
            };
            //Console.WriteLine(bill.Invoke(10));
            string msg = bill.Invoke(10);
            Console.WriteLine(msg);
        }

        // Example 2
        public delegate void Bill2 (int money);
        public static void PrintBill2()
        {
            Bill2 bill = delegate (int money)
            {
                Console.WriteLine($"Ex2: You spend {money}$ for food.");
            };
            bill(20);
        }
    }
}
