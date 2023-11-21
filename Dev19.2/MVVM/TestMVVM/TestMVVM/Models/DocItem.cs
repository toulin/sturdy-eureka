using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVVM.Models
{
    public class DocItem
    {
        public DocItem(int docNo, string docName, string docType)
        {
            DocNo = docNo;
            DocName = docName;
            DocType = docType;
        }

        public int DocNo { get; set; }

        public string DocName { get; set; }

        public string DocType { get; set; } = string.Empty;
    }
}
