using Reguto.Annotations;
using Reguto.Annotations.DI;

namespace Reguto.Test.FakeObjects
{
    [Injectable(InjectionMode.Transient)]
    class Injectable : IInjectable
    {
    }
}
