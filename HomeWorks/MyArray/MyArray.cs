using System;
using System.IO;

namespace MyArrays
{
    public class MyArray
    {
        int[] arr;

        /// <summary>
        /// Конструктор, создающий массив заданной размерности и заполняющий массив 
        /// числами от начального значения с заданным шагом
        /// </summary>
        /// <param name="size">размер массива</param>
        /// <param name="item0">начальный элемент массива</param>
        /// <param name="step">шаг от начального значения</param>
        public MyArray(uint size = 0, int item0 = 0, ushort step = 1)
        {
            arr = new int[size];

            // заполним массив
            for (uint i = 0; i < size; i++)
                arr[i] = item0 + Convert.ToInt32(i) * Convert.ToInt32(step);
        }

        /// <summary>
        /// Индексатор массива
        /// </summary>
        /// <param name="i">индекс элемента</param>
        /// <returns></returns>
        public int this[uint i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        /// <summary>
        /// Выводит все элементы массива в строку (в столбик).
        /// </summary>
        /// <returns></returns>
        public string ToStringAll()
        {
            string s = "";
   
            for (uint i = 0; i < arr.Length; i++)
                s += $"\n{arr[i]}";

            return s;
        }

        /// <summary>
        /// Возвращает длину массива.
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return arr.Length;
        }

        /// <summary>
        /// Сумма всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int s = 0;

            for (uint i = 0; i < arr.Length; i++)
                s += arr[i];

            return s;
        }

        /// <summary>
        /// Инверитирует все элементы массива ()умножает на -1.
        /// Частный случай метода Multi.
        /// </summary>
        /// <param name="z">-1</param>
        public void Inverse(int z=-1)
        { 
            for (uint i = 0; i < arr.Length; i++)
                arr[i] *= z;
        }

        /// <summary>
        /// Умножает каждый элемент массива на множитель
        /// </summary>
        /// <param name="z">множитель</param>
        public void Multi(int z)
        {
            Inverse(z);
        }

        /// <summary>
        /// Возвращает максимальный элемент в массиве
        /// </summary>
        /// <returns></returns>
        public int Max()
        {
            int maxValue = 0;

            for (uint i = 0; i < arr.Length; i++)
                if (arr[i] > maxValue) maxValue = arr[i];

            return maxValue;
        }

        /// <summary>
        /// Возвращает количество элементов по значению
        /// </summary>
        /// <param name="v">Искомое значение</param>
        /// <returns></returns>
        public int Count(int v)
        {
            int countValue = 0;

            for (uint i = 0; i < arr.Length; i++)
                if (arr[i] == v) countValue++;

            return countValue;
        }

        /// <summary>
        /// Загружает элементы массива из файла.
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public bool InArray(string filename)
        {
            bool result;

            //Если файл существует
            if (File.Exists(filename))
            {
                //Считываем все строки в файл 
                string[] str = File.ReadAllLines(filename);

                for (int i = 0; i < Math.Min(str.Length, arr.Length); i++)
                    arr[i] = int.Parse(str[i]);

                result = true;
            }
            else result = false;

            return result;
        }

        /// <summary>
        /// Выгружает элементы массива в файл
        /// </summary>
        /// <param name="filename">имя файла</param>
        public void OutArray(string filename)
        {
            File.WriteAllText(filename, ToStringAll());
        }

        }
}
