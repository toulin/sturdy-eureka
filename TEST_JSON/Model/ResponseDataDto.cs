using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_JSON.Models
{
    /// <summary>
    /// 查詢資料結果
    /// </summary>
    public class ResponseDataDto
    {
        /// <summary>
        /// 欄位資訊
        /// </summary>
        public List<ColumnDto> columns { get; set; }

        /// <summary>
        /// 資料
        /// </summary>
        public List<List<object>> datas { get; set; }
    }
}
