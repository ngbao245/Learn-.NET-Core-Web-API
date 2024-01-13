using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CallbackDelegate
{
    public static class CallbackFunc
    {
        public static void BuyFood(string Food, Func<int, string, bool> func)
        {
            Console.WriteLine("You go to the store.");
            if (func.Invoke(3, "Pizza"))
            {
                Console.WriteLine($"You spent 100$.");
            }else
            {
                Console.WriteLine($"You don't have enough money.");
            }
        }

        public static bool Cashier(int quantity, string foodType)
        {
            Console.WriteLine($"You buy {quantity} {foodType}.");
            return true;
        }
    }
}
