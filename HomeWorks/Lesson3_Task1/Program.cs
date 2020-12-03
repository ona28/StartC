using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson3_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("1. Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.");

            Complex a = new Complex();
            Complex b = new Complex();

            a.Re = 5; 
            a.Im = 10;

            b.Re = 8;
            b.Im = 3;

            Complex result;

            Console.WriteLine($"Даны два комплексных числа: {a.ToString()} и {b.ToString()}.");
                        
            result = a.Multiplication(b);
            Console.WriteLine($"Произведение чисел равно: {result.ToString()}");

            result = a.Subtraction(b);
            Console.WriteLine($"Вычитание чисел равно: {result.ToString()}");

            SignatureONA.End();
        }
    }
}
