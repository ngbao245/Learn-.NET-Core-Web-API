using LINQ;
using LINQ.LambdaExpression;
using static LINQ.LambdaExpression.Lambda;

public class Program
{
    public static void Main(string[] args)
    {
        //Test.ExtensionMethod();

        //Test.Delegate1();
        //Test.Delegate2();
        //Test.Action();
        //Test.Predicate();
        //Test.Func();

        //Test.AnonymousMethod1();
        //Test.AnonymousMethod2();

        var lambda = () =>
        {
            Console.WriteLine("This is lambda expression");
        };
        lambda();
    }



}
