using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    class Stationary : IStationary
    {
        public string Dial(string number)
        {
            if (Validator.ValidatePhone(number))
            {
                return $"Dialing... {number}";
            }
            return "Invalid number!";
        }
    }
}
