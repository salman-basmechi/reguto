using System;

namespace Reguto.Annotations.Options
{
    /// <summary>
    /// Annotate class as options.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class OptionsAttribute : Attribute
    {
        /// <summary>
        /// Create new instance, section mode used to bind application settings property to annotated class.
        /// </summary>
        /// <param name="section"></param>
        public OptionsAttribute(string section)
        {
            Section = section ?? throw new ArgumentNullException(nameof(section));
        }

        /// <summary>
        /// Section name
        /// </summary>
        public string Section { get; }
    }
}
