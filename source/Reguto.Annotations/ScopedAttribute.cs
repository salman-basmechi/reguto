using System;

namespace Reguto.Annotations
{
    /// <summary>
    /// Annotate as scoped class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
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
