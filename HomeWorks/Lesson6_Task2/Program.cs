using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivateFunctions;

namespace Lesson6_Task2
{

    class Program
    {
        
        static void Main(string[] args)
        {

            SignatureONA.Start("2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата." +
                "\nа) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум." +
                "\nб) Используйте массив(или список) делегатов, в котором хранятся различные функции." +
                "\nв) *Переделайте функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр out.");

            MyMenu menu = new MyMenu();
            menu.ChoiceF();

            SignatureONA.End();
        }
    }
}
