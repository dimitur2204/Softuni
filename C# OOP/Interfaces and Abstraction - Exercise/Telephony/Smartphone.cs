using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string BrowseWeb(string website)
        {
            if (Validator.ValidateURL(website))
            {
                return $"Browsing: {website}!";
            }
            return $"Invalid URL!" ;
        }

        public string Call(string number)
        {
            if (Validator.ValidatePhone(number))
            {
                return $"Calling... {number}";
            }
            return "Invalid number!";
        }
    }
}
