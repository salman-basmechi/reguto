using System;

namespace Reguto.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class InjectableAttribute : Attribute
    {
        public InjectableAttribute(InjectionMode mode)
        {
            Mode = mode;
        }

        public InjectionMode Mode { get; }

        public bool AsSelf { get; init; }
    }
}
