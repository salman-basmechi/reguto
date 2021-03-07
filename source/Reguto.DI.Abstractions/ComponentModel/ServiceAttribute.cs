using System;

namespace Reguto.DI.Abstractions.ComponentModel
{
    /// <summary>
    /// Annotate as service class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ServiceAttribute : ScopedAttribute
    {
    }
}
