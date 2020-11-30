using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson2_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("3. С клавиатуры вводятся числа, пока не будет введен 0. \nПодсчитать сумму всех нечетных положительных чисел.");
            
            int result = 0;
            bool end = false;
            int x;

            while (!end)
            {
                x = GeneralONA.RequestValue("Введите число:", true, true);

                if (!(x%2 == 0)) result += x;
                if (x == 0) break;                   
            }
            
            Console.Write($"Cумма всех нечетных положительных чисел: {result}");
            SignatureONA.End();
        }
    }
}
