using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Task1.GameFolder
{
    public interface IView
    {
        string Number { set; }
        string Counter { set; }
        string StartNumber { set; }
        bool BackEnable { set; }
    }
    
}
