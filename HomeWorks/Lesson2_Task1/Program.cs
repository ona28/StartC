using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("1. Написать метод, возвращающий минимальное из трех чисел.");
            int result;

            int x1 = 0;
            int x2 = 0;
            int x3 = 0;

            x1 = GeneralONA.RequestValue("Введите первое число:", true, true);
            x2 = GeneralONA.RequestValue("Введите второе число:", true, true);
            x3 = GeneralONA.RequestValue("Введите третье число:", true, true);

            result = x1;
            if (x1 > x2) result = x2;                       
            if (result > x3) result = x3;

            Console.Write($"Минимальное число: {result}");

            SignatureONA.End(); 
        }
    }
}
