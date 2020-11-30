using System;

namespace PrivateFunctions
{
    public class SignatureONA
    {
        /// <summary>
        /// Подставляет в шапку проекта описание задачи и автора.
        /// </summary>
        /// <param name="description">Описание задачи</param>
        public static void Start(string description)
        {
            Console.WriteLine("автор проекта: Орлова Наталья.");
            Console.WriteLine($"{description}");
            Console.WriteLine("...");
        }

        public static void End()
        {
            Console.ReadKey();
        }
    }

    public class GeneralONA
    {
        /// <summary>
        /// Функция запрашивает значение для ввода пользователя. 
        /// Проверяет значение на число (по умолчанию false).
        /// </summary>
        /// <param name="description">Описание переменной - Например: "Введите число х:"</param>
        /// <param name="checkNumber">проверка на число: да/нет (по умолчанию - нет)</param>
        /// <param name="lineBreak">перенос строки: да/нет (по умолчанию - нет)</param>
        public static int RequestValue(string description, bool checkNumber = false, bool lineBreak = false)
        {
            int result = 0;

            if (lineBreak) Console.WriteLine($"{description}");
            else Console.Write($"{description}");

            string answer = Console.ReadLine();

            if (checkNumber) // проверка на число
            {
                double a;
                bool check;
                check = double.TryParse(answer, out a);
                if (!check)
                {
                    Console.WriteLine("Вы ввели некорректное значение!");
                    return result;
                }
            }
            
            result = Convert.ToInt32(answer);       
            return result;
        }
    }
}
