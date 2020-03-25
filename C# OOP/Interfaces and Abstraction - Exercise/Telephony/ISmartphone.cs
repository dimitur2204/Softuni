using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    interface ISmartphone
    {
        public string Call(string number);
        public string BrowseWeb(string website);
    }
}
