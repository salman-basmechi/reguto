using System;

namespace Reguto.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OptionsAttribute : Attribute
    {
        public OptionsAttribute(string section)
        {
            Section = section ?? throw new ArgumentNullException(nameof(section));
        }

        public string Section { get; }
    }
}
