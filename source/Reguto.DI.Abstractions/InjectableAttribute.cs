using System;

namespace Reguto.DI.Abstractions
{
    /// <summary>
    /// Annotate as injectable class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
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
