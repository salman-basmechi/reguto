using System;

namespace Reguto.Annotations
{
    /// <summary>
    /// Annotate as scoped class by singleton lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
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
