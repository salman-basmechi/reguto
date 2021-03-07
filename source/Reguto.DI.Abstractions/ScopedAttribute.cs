using System;

namespace Reguto.DI.Abstractions
{
    /// <summary>
    /// Annotate as scoped class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedAttribute : InjectableAttribute
    {
        /// <summary>
        /// Create new instance.
        /// </summary>
        public ScopedAttribute() : base(InjectionMode.Scoped)
        {
        }
    }
}
