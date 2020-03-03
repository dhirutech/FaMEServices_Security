using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaMEServices.Utilities
{
    public static class ModelValidation
    {
        public static T ParseEnum<T>(T value, Type enumObj)
        {
            if (Enum.IsDefined(enumObj, value))
            {
                return value;
            }
            else
            {
                throw new InvalidCastException($"{value} is not a valid Type");
            }
        }
    }
}
