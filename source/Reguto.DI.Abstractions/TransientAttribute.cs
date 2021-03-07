using System;

namespace Reguto.DI.Abstractions
{
    /// <summary>
    /// Annotate as scoped class by transient lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TransientAttribute : InjectableAttribute
    {
        /// <summary>
        /// Create new instance.
        /// </summary>
        public TransientAttribute() : base(InjectionMode.Transient)
        {
        }
    }
}
