using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.LambdaExpression
{
    public class Lambda
    {
        public delegate void DelegateDisplay(string message);

        DelegateDisplay dlg = delegate (string qua) { Console.WriteLine("Tặng quà" + qua); };
    }
}
