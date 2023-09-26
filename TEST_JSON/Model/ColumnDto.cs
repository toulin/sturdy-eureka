using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_JSON.Models
{
    /// <summary>
    /// 欄位資訊
    /// </summary>
    public class ColumnDto
    {
        /// <summary>
        /// 欄位名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 資料型態
        /// </summary>
        public string DataTypeName { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is ColumnDto)
            {
                var target = obj as ColumnDto;
                return this.Name.Equals(target.Name) && this.DataTypeName.Equals(target.DataTypeName);
            }
            return false;   
        }
    }
}
