using System;

namespace Reguto.DI.Abstractions.ComponentModel
{
    /// <summary>
    /// Annotate as repository class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RepositoryAttribute : ScopedAttribute
    {
    }
}
