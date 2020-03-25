using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    interface IResident
    {
        public string name { set; }
        public string country { get; }
        public string GetName();

    }
}
