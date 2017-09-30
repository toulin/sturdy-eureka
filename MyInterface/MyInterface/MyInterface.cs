using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyInterface
{
    interface IMyInterface<T>
    { 
        void Add(T param);
    }
}
