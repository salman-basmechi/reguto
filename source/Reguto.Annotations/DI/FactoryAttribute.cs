using System;

namespace Reguto.Annotations.DI
{
    /// <summary>
    /// Annotate as factory class by singleton lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FactoryAttribute : SingletonAttribute
    {
    }
}
