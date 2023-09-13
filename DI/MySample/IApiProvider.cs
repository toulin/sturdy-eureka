using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    public interface IApiProvider
    {
        string GetAPI(string id);
    }
}
