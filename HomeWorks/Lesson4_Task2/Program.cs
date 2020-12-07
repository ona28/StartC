using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;
using MyArrays;

namespace Lesson4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("2. а) Дописать класс для работы с одномерным массивом. Реализовать конструктор," +
                "\nсоздающий массив заданной размерности и заполняющий массив числами от начального значения с " +
                "\nзаданным шагом. Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, " +
                "\nменяющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент массива на определенное число, " +
                "\nсвойство MaxCount, возвращающее количество максимальных элементов. В Main продемонстрировать работу класса. " +
                "\n\nб)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.");

            MyArrays.MyArray arr = new MyArrays.MyArray(15, -10000, 3878);

            Console.WriteLine($"Дан массив чисел: {arr.ToStringAll()}");

            // Сумма элементов массива
            Console.WriteLine($"\nСумма элементов массива: {arr.Sum()}");

            // поменяем знаки у всех элементов
            arr.Inverse();
            Console.WriteLine($"\nРезультат метода массива Inverse (инвертирование знака): {arr.ToStringAll()}");

            // умножить каждый элемент массива на число
            arr.Multi(3);
            Console.WriteLine($"\nРезультат метода массива Multi (умножение на число): {arr.ToStringAll()}");

            // максимальный элемент в массиве
            int mv = arr.Max();
            Console.WriteLine($"\nКоличество максимальных элементов ({mv}): {arr.Count(mv)}");

            // загрузить из файла в массив
            Console.Write("Введите имя файла для загрузки в массив:");
            string f = Console.ReadLine();
            bool r = arr.InArray(f);

            if (r)
                Console.WriteLine($"Загруженный массив чисел: {arr.ToStringAll()}");
            else Console.WriteLine("Ошибка загрузки файла!");

            // сохранить в файл
            try { 
                arr.OutArray(f); 
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Неверный путь к файлу!"); 
            }
            catch (IOException)
            {
                Console.WriteLine("Ошибка ввода!");
            }
            // и т.д.
            finally { }            

            SignatureONA.End();
        }
    }
}
