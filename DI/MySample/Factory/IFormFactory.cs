using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySample.Factory
{
    public interface IFormFactory
    {
        T Create<T>() where T : Form;
        T CreateInstance<T>();
    }
}
