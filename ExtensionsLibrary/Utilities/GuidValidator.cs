using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsLibrary.Utilities
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class GuidValidator : ValidationAttribute
    {
        public GuidValidator():base("The {0} field requires a non-default value.")
        {

        }
        public override bool IsValid(object? value)
        {
            if (value is null)
            {
                return false;
            }
            var type = value.GetType();
            return !Equals(value, Activator.CreateInstance(Nullable.GetUnderlyingType(type) ?? type));
        }
    }
}
