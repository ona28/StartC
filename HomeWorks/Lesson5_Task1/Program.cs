using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;
using System.Text.RegularExpressions;

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

            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            // 1. способ -----------------------------------------------------------
            bool correct1 = login.Length > 2 && login.Length <= 10;
            char[] arr = login.ToCharArray();

            // проверка на первую цифру
            if (correct1) correct1 = !Char.IsDigit(login, 0);

           string allSimbols = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ0123456789";

            if (correct1)
            {
                for (uint i = 0; i < login.Length; i++)
                {
                    if (allSimbols.IndexOf(arr[i]) == -1)
                    {
                        correct1 = false;
                        break;
                    }
                }
            }

            Console.WriteLine((correct1)? "Логин корректный!": "Логин некорректный!");

            // 2. способ -----------------------------------------------------------
            bool correct2 = login.Length > 2 && login.Length <= 10;

            if (correct2)
            {
                string s = @"^[\D]{1}[a-zA-Z0-9]+$";
                Regex myReg = new Regex(s);
                correct2 = myReg.IsMatch(login);
            }
            Console.WriteLine((correct2) ? "Логин корректный!" : "Логин некорректный!");

            SignatureONA.End();
        }
    }
}
