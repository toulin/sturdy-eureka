using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVVM.Models
{
    public class TreeNodeData
    {
        public TreeNodeData(int id, int parentID, DocItem item) 
        {
            Id = id;
            ParentId = parentID;
            Item = item;
        }

        public int Id { get; set; }
        public int ParentId { get; set; }

        public DocItem Item { get; set; }

        public string Name { get => Item.DocName; }
    }
}
