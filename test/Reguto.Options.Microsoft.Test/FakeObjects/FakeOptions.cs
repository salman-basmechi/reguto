using Reguto.Options.Abstractions;

namespace Reguto.Options.Microsoft.Test.FakeObjects
{
    [Options("Fake")]
    internal class FakeOptions
    {
        public int Id { get; init; }

        public string? Secret { get; init; }
    }
}
