using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : List<Type>, IAddCollection
    {
        public List<string> BaseList { get; set; } = new List<string>();
        public int Add(string item)
        {
            BaseList.Add(item);
            return BaseList.LastIndexOf(item);
        }
    }
}
