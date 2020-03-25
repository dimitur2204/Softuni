using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    class MyList : AddRemoveCollection
    {
        public int Used => BaseList.Count;
        public override string Remove()
        {
            var first = BaseList[0];
            BaseList.RemoveAt(0);
            return first;
        }
    }
}
