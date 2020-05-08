
using System;
using System.Reflection;

namespace ValidationAttributes
{
    using System.Linq;
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
        {
            return MyRequiredAttribute.IsDefined((Assembly)obj, obj.GetType());
        }
    }
}
