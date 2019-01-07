// Copyright Lokad 2018 under MIT BCH.
using CashDB.Lib.Messaging;
using Xunit;

namespace CashDB.Lib.Tests.Messaging
{
    public class OutpointTests
    {
        [Fact]
        public unsafe void SizeInBytes()
        {
            Assert.Equal(Outpoint.SizeInBytes, sizeof(Outpoint));
        }

        [Fact]
        public void Outpoint_GetHashCode()
        {
            var outpoint = new Outpoint();
            outpoint.GetHashCode();
        }
    }
}
