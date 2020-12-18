using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Task2
{
    interface IForm
    {
        string Message { set; }
        string Counter { set; }
        int Unknown { get; set; }
    }
}
