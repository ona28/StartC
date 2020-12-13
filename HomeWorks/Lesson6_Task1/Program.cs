using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson6_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("1. Изменить программу вывода функции так, чтобы можно было передавать функции  типа double" +
                "\n(double,double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).");

            MyFunctions fs = new MyFunctions();
            fs.Table(fs.MyFunc1, -10, 5, 2);
            fs.Table(fs.MyFunc2, -10, 5, 2);

            SignatureONA.End();
        }
    }
}
