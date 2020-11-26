using System;

namespace Reguto.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class TransientAttribute : InjectableAttribute
    {
        public TransientAttribute() : base(InjectionMode.Transient)
        {
        }
    }
}
