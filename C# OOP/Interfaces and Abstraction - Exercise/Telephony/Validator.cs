using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Telephony
{
    public class Validator
    {
        public static bool ValidatePhone(string number) 
        {
            var regex = @"[^0-9]";
            if (Regex.Matches(number, regex).Count > 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateURL(string URL) 
        {
            var regex = @"[0-9]";
            if (Regex.Matches(URL,regex).Count > 0)
            {
                return false;   
            }
            return true;
        }
    }
}
