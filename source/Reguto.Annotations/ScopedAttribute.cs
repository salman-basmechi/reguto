using System;

namespace Reguto.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ScopedAttribute : InjectableAttribute
    {
        public ScopedAttribute() : base(InjectionMode.Scoped)
        {
        }
    }
}
