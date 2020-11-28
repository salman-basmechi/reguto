using System;

namespace Reguto.Annotations.DI
{
    /// <summary>
    /// Annotate as injectable class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InjectableAttribute : Attribute
    {
        /// <summary>
        /// Create new instance by entry mode.
        /// </summary>
        /// <param name="mode"></param>
        public InjectableAttribute(InjectionMode mode)
        {
            Mode = mode;
        }

        /// <summary>
        /// Get injection mode
        /// </summary>
        public InjectionMode Mode { get; }

        /// <summary>
        /// Register class as itself or not.
        /// </summary>
        public bool AsSelf { get; init; }
    }
}
