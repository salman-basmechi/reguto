using System;

namespace Reguto.Annotations.DI
{
    /// <summary>
    /// Annotate as repository class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RepositoryAttribute : ScopedAttribute
    {
    }
}
