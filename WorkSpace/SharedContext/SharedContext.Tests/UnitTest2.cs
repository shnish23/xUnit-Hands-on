using System;
using SharedContext.Tests.Fixtures;
using Xunit;

namespace SharedContext.Tests
{
    [Collection("Heavy collection")]
    public class UnitTest2 : IDisposable
    {
        private readonly HeavyFixture _heavyFixture;

        public UnitTest2()
        {
            _heavyFixture = new HeavyFixture();
        }

        [Fact]
        public void Test() => _heavyFixture.Use();

        public void Dispose()
        {
            _heavyFixture.Dispose();
        }
    }
}