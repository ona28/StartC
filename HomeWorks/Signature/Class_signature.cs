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

    public class Complex 
    {
        double re;
        double im;

        public Complex()
        {
            re = 0;
            im = 0;
        }

        // Сложение двух комплексных чисел
        public Complex Add(Complex x)
        {
            Complex y = new Complex
            {
                re = re + x.re,
                im = im + x.im
            };
            return y;
        }

        //  Вычитание двух комплексных чисел
        public Complex Subtraction(Complex x)
        {
            Complex y = new Complex
            {
                re = re - x.re,
                im = im - x.im
            };
            return y;
        }

        //  Произведение двух комплексных чисел
        public Complex Multiplication(Complex x)
        {
            Complex y = new Complex
            {
                re = re * x.re - im * x.im,
                im = im * x.re + re * x.im
            };
            return y;
        }

        //  Деление двух комплексных чисел
        public Complex Division(Complex x)
        {
            Complex y = new Complex
            {
                re = (re * x.re + im * x.im) / (x.re * x.re + x.im * x.im),
                im = (im * x.re - re * x.im) / (x.re * x.re + x.im * x.im)
            };
            return y;
        }

        public double Re
        {
            get { return re; }
            set { re = value; }
        }

        public double Im
        {
            get { return im; }
            set {im = value; }
        }

        public string ToString()
        {
            return re + "+" + im + "i";
        }


    }

    public class myDecimal
    {
        int num;
        int den;

        public myDecimal(int num = 0, int den = 1)
        {
            this.num = num;
            this.den = den;
        }

        // Сложение двух дробей
        public myDecimal Add(myDecimal x)
        {
            myDecimal y = new myDecimal
            {
                num = num*x.den + x.num*den,
                den = den * x.den
            };

            // нужно сократить дробь, 
            // найти наибольший общий знаменатель

            return y;
        }

        //  Вычитание двух дробей
        public myDecimal Subtraction(myDecimal x)
        {
            myDecimal y = new myDecimal
            {
                num = num * x.den - x.num * den,
                den = den * x.den
            };

            // нужно сократить дробь, 
            // найти наибольший общий знаменатель

            return y;
        }

        //  Произведение двух дробей
        public myDecimal Multiplication(myDecimal x)
        {
            myDecimal y = new myDecimal
            {
                num = num * x.num,
                den = den * x.den
            };

            // нужно сократить дробь, 
            // найти наибольший общий знаменатель

            return y;
        }

        //  Деление двух дробей
        public myDecimal Division(myDecimal x)
        {
            myDecimal y = new myDecimal
            {
                num = num * x.den,
                den = den * x.num
            };

            // нужно сократить дробь, 
            // найти наибольший общий знаменатель

            return y;
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

        public int Den
        {
            get { return den; }
            set { den = value; }
        }

        public string ToString()
        {
            return num + "/" + den;
        }

    }
}
