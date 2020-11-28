namespace Reguto.Annotations
{
    /// <summary>
    /// Dependency injection mode
    /// </summary>
    public enum InjectionMode
    {
        /// <summary>
        /// Singleton lifetime
        /// </summary>
        Singleton = 1,

        /// <summary>
        /// Scoped lifetime
        /// </summary>
        Scoped = 2,
        
        /// <summary>
        /// Transient lifetime
        /// </summary>
        Transient = 3
    }
}
