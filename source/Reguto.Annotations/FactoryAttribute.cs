using System;

namespace Reguto.Annotations
{
    /// <summary>
    /// Annotate as factory class by singleton lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class FactoryAttribute : SingletonAttribute
    {
    }
}
