using System;

namespace Reguto.DI.Abstractions.ComponentModel
{
    /// <summary>
    /// Annotate as factory class by singleton lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FactoryAttribute : SingletonAttribute
    {
    }
}
