using System;
using System.Collections.Generic;
using PrivateFunctions;

namespace Lesson6_Task2
{
    class MyMenu
    {
        public void ChoiceF()
        {
            MyFunctions MF = new MyFunctions();

            Dictionary<int, MyFunctions.Fun> ls = new Dictionary<int, MyFunctions.Fun>();
            Dictionary<int, string> sl = new Dictionary<int, string>();

            ls[1] = (x) => x * x - 50 * x + 10;
            ls[2] = (x) => x * x + 10;
            ls[3] = (x) => x * x - 145;
            ls[4] = (x) => Math.Sin(x);
            ls[5] = (x) => Math.Cos(x);

            sl[1] = "f = x * x - 50 * x + 10";
            sl[2] = "f = x * x + 10";
            sl[3] = "f = x * x -145";
            sl[4] = "f = Sin(x)";
            sl[5] = "f = Cos(x)";

            foreach (var f in sl)
            {
                Console.WriteLine($"{f.Key}. {f.Value}");
            }
            int it = GeneralONA.RequestValue("Введите номер выполняемой функции:", true);

            MyFunctions.Fun ff;

            try
            {
                ff = ls[it];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Нет функции под номером {it}!");
                return;
            }

            MF.SaveFunc("data.txt", ff, -100, 100, 0.5);
            MF.Load("data.txt", out double min);
            Console.WriteLine($"Минимум функции: {min}");
        }
    }
}
