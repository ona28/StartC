using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson5_Task2
{
    class myMessage
    {
        private string txt;

        public myMessage() 
        {
        }

        public string Txt
        {
            get => txt;
            set => txt = value;
        }

        private string[] StringToArray()
        {
            char[] sep = new char[] { ' ', '.', ',' };
            string[] wolds = txt.Split(sep);

            return wolds;
        }

        /// <summary>
        /// Метод, оставляющий в тексте слова не более n символов
        /// </summary>
        /// <param name="n">число символов</param>
        /// <returns></returns>
        public string Cut(byte n)
        {
            string rezult = "";
            string[] wolds = StringToArray();

            for (uint i = 0; i < wolds.Length; i++)
            {
                if (wolds[i].Length > n || wolds[i].Length == 0) continue;
                rezult += $"{wolds[i]} ";
            }

            return rezult;
        }

        /// <summary>
        /// Удаление из строки слов, заканчивающихся на заданый символ
        /// </summary>
        /// <param name="s">заданый символ</param>
        /// <returns></returns>
        public string Del(char s)
        {
            string rezult = "";

            Regex myReg = new Regex($@"\w+[{s}]\b", RegexOptions.IgnoreCase);
            MatchCollection mc = myReg.Matches(txt);
           
            foreach (Match match in mc) rezult += $"{match.Value} ";
            return rezult;
        }

        /// <summary>
        /// Поиск максимального слова из текста
        /// </summary>
        /// <returns></returns>
        public (byte, string) Max()
        {
            (byte, string) rezult = (0, "");
            StringBuilder sb = new StringBuilder();
            string[] wolds = StringToArray();

            if (wolds.Length == 0) return rezult;

            for (uint i = 0; i < wolds.Length; i++) rezult.Item1 = Math.Max(Convert.ToByte(wolds[i].Length), rezult.Item1);
            for (uint i = 0; i < wolds.Length; i++)
            {
                if (Convert.ToByte(wolds[i].Length) == rezult.Item1) sb.Append(wolds[i] + @" ");
            }

            rezult.Item2 = sb.ToString();
            return rezult;
        }
        
    }
}
