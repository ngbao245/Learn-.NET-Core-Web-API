using static LINQ.LambdaExpression.AnonymousMethod;

namespace LINQ.CallbackDelegate
{
    // Example 1
    //Delegate to declare callback function
    public delegate void TimerCallback();

    public class CallbackDelegate
    {
        int seconds;
        TimerCallback callback;

        public CallbackDelegate(int seconds, TimerCallback callback)
        {
            this.seconds = seconds;
            this.callback = callback;
        }

        public void Start()
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine($"Seconds left: {i}");
                Thread.Sleep(1000);
            }
            callback?.Invoke();
        }

        public static void Message()
        {
            Console.WriteLine("Time's up");
        }

        // Example 2

        public delegate int TipsBox(int tips);
        public static void Display(TipsBox donate)
        {
            donate = Donate; // assigning the method Donate to the delegate variable donate.
            TipsBox tipDelegate = donate;
            Console.WriteLine($"The waiter earn {tipDelegate(10)}$"); // Callback to the function Donate
        }
        public static int Donate(int tips)
        {
            Console.WriteLine($"You tips: {tips}$");
            return tips;
        }
    }
}
