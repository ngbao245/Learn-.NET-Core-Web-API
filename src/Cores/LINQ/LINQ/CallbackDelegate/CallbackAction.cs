using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CallbackDelegate
{
    public static class CallbackAction
    {
        public static void PayMoney(int money, Action<int, string> callback)
        {
            if (money >= 1000)
            {
                Console.WriteLine($"You spent 1000$");
                callback?.Invoke(2, "Iphone15");
            }
            else
            {
                Console.WriteLine("You don't have enough money to purchase.");
            }
        }

         public static void GetIphone(int amount, string iphone)
        {
            Console.WriteLine($"You got {amount} new {iphone}.");
        }

    }
}
