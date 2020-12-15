using System.IO;

namespace Lesson6_Task2
{
    class MyFunctions
    {
        public delegate double Fun(double x);
        
        public void SaveFunc(string fileName, Fun F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }

        // переделана возвращать массив, минимум через параметр out
        public double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double[] rezult = new double[fs.Length / sizeof(double)];

            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
                rezult[i] = d;
            }
            bw.Close();
            fs.Close();
            return rezult;
        }
    }
}
