using LINQ.ExtensionMethod;
using LINQ.CallbackDelegate;
using LINQ.LambdaExpression;


namespace LINQ
{
    public static class Test
    {
        // Extension Method
        public static void ExtensionMethod()
        {
            // Without Extension Method
            Student John = new Student
            {
                Name = "John",
                Age = 10,
            };

            John.SayHello();
            //John.PrintInfo(); Error if Without Extension Method

            Student Unknown = new Student();
            Unknown.SayHello();

            // With Extension Method
            Student JohnExtensionMethod = new Student
            {
                Name = "John",
                Age = 10,
            };
            JohnExtensionMethod.PrintInfo();
        }

        // Callback & Delegate
        public static void Delegate1()
        {
            CallbackDelegate.CallbackDelegate delegateTimer = new CallbackDelegate.CallbackDelegate(3, CallbackDelegate.CallbackDelegate.Message);
            delegateTimer.Start();
        }

        public static void Delegate2()
        {
            CallbackDelegate.CallbackDelegate.Display(CallbackDelegate.CallbackDelegate.Donate);
        }

        public static void Action()
        {
            //CallbackAction action = new CallbackAction();
            CallbackAction.PayMoney(1000, CallbackAction.GetIphone);
        }

        public static void Predicate()
        {
            //CallbackPredicate predicate = new CallbackPredicate();
            CallbackPredicate.Gift("Flower", CallbackPredicate.HaveFlower);
        }

        public static void Func()
        {
            //CallbackFunc func = new CallbackFunc();
            CallbackFunc.BuyFood("Pizza", CallbackFunc.Cashier);
        }

        // Anonymous Method & Lambda Expression
        public static void AnonymousMethod1()
        {
            AnonymousMethod.PrintBill1();
        }

        public static void AnonymousMethod2()
        {
            AnonymousMethod.PrintBill2();
        }
    }
}
