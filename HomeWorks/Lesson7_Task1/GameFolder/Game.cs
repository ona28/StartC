using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Task1.GameFolder
{
    public class Game
    {
        IView view;
        int n, p , c;
        public Game(IView view)
        {
            n = 0;
            p = 0;
            c = 0;
            this.view = view;
            ReloadView();
        }

        private void ReloadView()
        {
            view.Number = $"Число:  {n}";
            view.Counter = $"Число ходов:  {c}";
        }

        public void Start()
        {
            var rand = new Random();
            view.StartNumber = $"Попробуйте получить число :  {rand.Next(1, 1000)} за минимальное число ходов.";
            view.BackEnable = false;
        }

        public void Plus()
        {
            p = n;
            n += 1;
            c += 1;
            ReloadView();
            view.BackEnable = true;
        }
        public void Mult()
        {
            p = n;
            n *= 2;
            c += 1;
            ReloadView();
            view.BackEnable = true;
        }

        public void Clear()
        {
            n = 0;
            p = 0;
            c = 0;
            ReloadView();
        }

        public void Back()
        {
            n = p;
            c= (c == 0)? 0 : c - 1;
            ReloadView();
            view.BackEnable = false;
        }
    }
}
