using Reguto.Annotations;

namespace Reguto.Test.FakeObjects
{
    [Injectable(InjectionMode.Transient, AsSelf = true)]
    class SelfService
    {
    }
}
