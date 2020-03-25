using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    internal class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public new int Add(string item)
        {
            BaseList.Insert(0,item);
            return 0;
        }
        public virtual string Remove()
        {
            var last = BaseList[BaseList.Count - 1];
            BaseList.RemoveAt(BaseList.Count - 1);
            return last;
        }
    }
}
