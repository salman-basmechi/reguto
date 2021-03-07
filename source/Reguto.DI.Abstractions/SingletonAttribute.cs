using System;

namespace Reguto.DI.Abstractions
{
    /// <summary>
    /// Annotate as scoped class by singleton lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonAttribute : InjectableAttribute
    {
        /// <summary>
        /// Create new instance.
        /// </summary>
        public SingletonAttribute() : base(InjectionMode.Singleton)
        {
        }
    }
}
