using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMExcelRTD
{
    internal class CMoneyTopic
    {
        internal CMoneyTopic(int _TopicID, string _CommID, string pName)
        {
            TopicID = _TopicID;
            CommID = _CommID;
            PropertyName = pName;
        }
        internal int TopicID { get; set; }
        internal string CommID { get; set; }
        internal string PropertyName { get; set; }
    }
}
