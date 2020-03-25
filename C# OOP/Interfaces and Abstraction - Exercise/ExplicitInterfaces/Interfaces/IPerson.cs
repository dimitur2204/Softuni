using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    interface IPerson
    {
        public string name { set; }
        public int age { get; }
        public string GetName();
    }
}
