using System;

namespace Reguto.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class SingletonAttribute : InjectableAttribute
    {
        public SingletonAttribute() : base(InjectionMode.Singleton)
        {
        }
    }
}
