using System;

namespace Reguto.Annotations
{
    /// <summary>
    /// Annotate as scoped class by transient lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
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
