﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interfaces
{
    interface IAddRemoveCollection : IAddCollection
    {
        public string Remove();
    }
}
