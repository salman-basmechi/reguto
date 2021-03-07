using Reguto.DI.Abstractions;

namespace Reguto.DI.Microsoft.Test.FakeObjects
{
    [Injectable(InjectionMode.Transient)]
    internal class Injectable : IInjectable
    {
    }
}
