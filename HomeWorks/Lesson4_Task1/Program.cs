using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;
using MyArrays;


namespace Lesson4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            SignatureONA.Start("1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать " +
                "\nцелые значения от –10 000 до 10 000 включительно. Написать программу, позволяющую найти " +
                "\nи вывести количество пар элементов массива, в которых хотя бы одно число делится на 3.");

            MyArrays.MyArray arr = new MyArrays.MyArray(20, -9001, 878);

            Console.WriteLine($"Дан массив чисел: {arr.ToStringAll()}");

            uint i;
            uint count = 0;

            for (i = 0; i < arr.Length(); i++)
            {
                if (i == 0) continue;
                if (arr[i - 1] % 3 == 0 || arr[i] % 3 == 0)
                    count++;
            }

            Console.WriteLine($"\nКоличество пар элементов массива, в которых хотя бы одно число делится на 3: {count}");
            SignatureONA.End();

        }
    }
}
