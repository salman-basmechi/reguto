using System;

namespace Reguto.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RepositoryAttribute : ScopedAttribute
    { 
    }
}
