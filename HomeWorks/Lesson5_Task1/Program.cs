using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson5_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином " +
                "\nбудет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, " +
                "\nпри этом цифра не может быть первой: " +
                "\nа) без использования регулярных выражений; " +
                "\nб) с использованием регулярных выражений.");


            SignatureONA.End();
        }
    }
}
