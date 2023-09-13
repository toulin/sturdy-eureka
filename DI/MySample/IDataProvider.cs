using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySample
{
    public interface IDataProvider
    {
        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string GetData(string id);
    }
}
