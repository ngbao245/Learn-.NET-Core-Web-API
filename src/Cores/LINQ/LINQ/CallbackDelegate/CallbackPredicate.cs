using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.CallbackDelegate
{
    public static class CallbackPredicate
    {
        public static void Gift(string present, Predicate<bool> predicate)
        {
            bool gift = HaveFlower(true);
            if (gift)
            {
                Console.WriteLine($"Give flower as a present.");
                Console.WriteLine("Your wife is happy.");
            }
            else
            {
                Console.WriteLine("Your wife is not happy.");

            }
        }

        public static bool HaveFlower(bool haveFlower)
        {
            return haveFlower;
        }
    }
}
