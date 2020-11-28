using System;

namespace Reguto.Annotations
{
    /// <summary>
    /// Annotate as repository class by scoped lifetime.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RepositoryAttribute : ScopedAttribute
    { 
    }
}
