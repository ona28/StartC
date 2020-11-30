using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson2_Task2
{
    class Program
    {
        static void Main(string[] args)
        {

            SignatureONA.Start("2. Написать метод подсчета количества цифр числа.");
            int result;

            int x = 0;
          
            x = GeneralONA.RequestValue("Введите число:", true, true);
            
            result = Convert.ToString(x).Length;
            
            Console.Write($"Число символов числа {x}: {result}");

            SignatureONA.End();
        }
    }
}
