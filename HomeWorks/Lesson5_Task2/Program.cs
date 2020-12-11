using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson5_Task2
{

    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("2. Разработать класс Message, содержащий следующие статические методы для обработки текста: " +
                "\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                "\nв) Найти самое длинное слово сообщения." +
                "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.");

            string origin = "В лесу родилась ёлочка, в лесу она росла. Зимой и летом стройная, зелёная была. " +
                            "Метель ей пела песенку, спи ёлочка бай-бай. Мороз снежком укутывал смотри не замерзай.";
            Console.WriteLine($"Строка - оригинал: {origin}");

            myMessage ms = new myMessage();
            ms.Txt = string.Copy(origin);

            // а) вывести слова не более n знаков
            Console.Write("\nа) Введите число букв искомых слов в тексте: ");
            byte n = Convert.ToByte(Console.ReadLine());
            string cuts = ms.Cut(n);
            Console.WriteLine($"Слова не более {n} букв: {cuts}");

            // б) Удалим из сообщения все слова, которые заканчиваются на заданный символ
            Console.Write("\nб) Удалим из сообщения все слова, которые заканчиваются на символ: ");
            char ch = Convert.ToChar(Console.ReadLine());
            string dels = ms.Del(ch);
            Console.WriteLine($"Результат: {dels}");

            // в) г) Найти самое длинное слово сообщения.
            (byte, string) maxs = ms.Max();            

            Console.WriteLine($"Самое длинные слова из {maxs.Item1} символов: {maxs.Item2}");

            SignatureONA.End();
        }
    }
}
