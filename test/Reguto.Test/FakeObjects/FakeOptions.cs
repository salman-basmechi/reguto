using Reguto.Annotations;
using Reguto.Annotations.Options;

namespace Reguto.Test.FakeObjects
{
    [Options("Fake")]
    class FakeOptions
    {
        public int Id { get; init; }

        public string Secret { get; init; }
    }
}
