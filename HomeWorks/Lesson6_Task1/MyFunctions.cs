using System;

namespace Lesson6_Task1
{ 
    public delegate double Fun(double x, double a);

    class MyFunctions
    {
        /// <summary>
        /// Печать таблицы результатов функции
        /// </summary>
        /// <param name="F">функция</param>
        /// <param name="x">аргумент х</param>
        /// <param name="a">аргумент а</param>
        /// <param name="b">предел</param>
        /// <param name="s">описание</param>
        public void Table(Fun F, double x, double a, double b)
        {
            Console.WriteLine("------- x ---------- a ----------- F ------");
            while (x <= b)
            {
                Console.WriteLine("| {0,11:0.000} | {1,11:0.000} | {2,11:0.000} |", x, a, F(x, a));
                x += 1;
                a -= 1;
            }
            Console.WriteLine("-------------------------------------------");
        }

        // Создаем методы для передачи в качестве параметра в Table
        public double MyFunc1(double x, double a)
        {
            return a * x * x;
        }

        public double MyFunc2(double x, double a)
        {
            return a * Math.Sin(x);
        }
    }
}
