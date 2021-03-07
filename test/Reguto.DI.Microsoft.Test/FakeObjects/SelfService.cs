using Reguto.DI.Abstractions;

namespace Reguto.DI.Microsoft.Test.FakeObjects
{
    [Injectable(InjectionMode.Transient, AsSelf = true)]
    internal class SelfService
    {
    }
}
