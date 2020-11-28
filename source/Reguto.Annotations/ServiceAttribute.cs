using System;

namespace Reguto.Annotations
{
    /// <summary>
    /// Annotate as service class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ServiceAttribute : ScopedAttribute
    {
    }
}
