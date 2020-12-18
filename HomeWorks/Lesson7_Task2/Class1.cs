using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Task2
{
    class Game
    {
        IForm view;
        int n, c;
        public Game(IForm view)
        {
            n = 0;        
            c = 0;
            this.view = view;
        }

        private void Reload()
        {
            view.Counter = $"Число попыток: {c}";
            view.Message = "";
        }

        public void Start()
        {
            var rand = new Random();
            n = rand.Next(1, 100);
            c = 0;
            Reload();
        }
        
        public void Check()
        {
            if (c == 10)
            {
                view.Message = $"Игра окончена. Для повтора \nнажмите ''Начать заново''.";
                view.Unknown = 0;
                return;
            }

            c += 1;
            Reload();

            if (view.Unknown == n) view.Message = $"Победа! Вы угадали!!!";
            else
            {                
                if (c == 10) view.Message = $"Игра окончена. Загаданное число: {n}." +
                                            "\nДля повтора нажмите ''Начать заново''.";
                else view.Message = $"Нет загаданное число {((view.Unknown < n) ? "больше" : "меньше")}." +
                                    "\nПопробуйте ещё раз.";
            }
        }
             
    }
}
