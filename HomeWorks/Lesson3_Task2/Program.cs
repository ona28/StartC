using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson3_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("3. *Описать класс дробей - рациональных чисел, являющихся отношением двух " +
                "\nцелых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. " +
                "\nНаписать программу, демонстрирующую все разработанные элементы класса.");

            myDecimal a = new myDecimal(5, 7);
            myDecimal b = new myDecimal(3, 6);

            myDecimal result;

            Console.WriteLine($"Даны две дроби: {a.ToString()} и {b.ToString()}.");

            result = a.Multiplication(b);
            Console.WriteLine($"Произведение дробей равно: {result.ToString()}");

            result = a.Division(b);
            Console.WriteLine($"Деление дробей равно: {result.ToString()}");

            result = a.Add(b);
            Console.WriteLine($"Сложение дробей равно: {result.ToString()}");

            result = a.Subtraction(b);
            Console.WriteLine($"Вычитание дробей равно: {result.ToString()}");

            Console.WriteLine("Дроби нужно еще сократить...(не успела пока).");

            SignatureONA.End();
        }
    }
}
