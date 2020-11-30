using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson2_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("4. Реализовать метод проверки логина и пароля. " +
                "\nНа вход подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел " +
                "\n(Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля," +
                "\n написать программу: пользователь вводит логин и пароль, программа пропускает" +
                "\n его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.");

            bool result = false;
            int x;
            byte i=1;

            do
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                string password = Console.ReadLine();

                if (login == "root" && password == "GeekBrains")
                {
                    result = true;
                    break;
                }
                else  Console.WriteLine("Неверный логин или пароль." + ((i < 3) ? " Попробуйте еще раз." : "") + "\n");
                   i++;
            }
            while (i <= 3);

            Console.Write($"\nРезультат ввода логина пароля: {result}");
            SignatureONA.End();
        }
    }
}
