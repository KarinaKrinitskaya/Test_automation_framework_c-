using System;

namespace TestAutomationFramework.Utilities
{
    public static class EnumUtils
    {
        public static T ParseEnum<T>(string value) where T : IComparable, IFormattable, IConvertible
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
