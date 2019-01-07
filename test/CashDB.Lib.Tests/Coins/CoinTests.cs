// Copyright Lokad 2018 under MIT BCH.
using System.Linq;
using CashDB.Lib.Chains;
using CashDB.Lib.Coins;
using CashDB.Lib.Messaging;
using Xunit;

namespace CashDB.Lib.Tests.Coins
{
    public unsafe class CoinTests
    {
        [Fact]
        public void GetSetOutpoint()
        {
            var buffer = new byte[4096];
            var coin = new Coin(buffer);

            Assert.Equal((Outpoint)default, coin.Outpoint);

            var outpoint = new Outpoint();
            for (var i = 0; i < 32; i++)
                outpoint.TxId[i] = (byte) i;
            outpoint.TxIndex = 42;

            coin.SetOutpoint(ref outpoint);

            Assert.Equal(outpoint, coin.Outpoint);
        }

        [Fact]
        public void GetSetOutpointFlags()
        {
            var buffer = new byte[4096];
            var coin = new Coin(buffer);

            Assert.Equal((CashDBOutpointFlags)default, coin.OutpointFlags);

            var flags = CashDBOutpointFlags.PersistentIsCoinbase;

            coin.OutpointFlags = flags;
            Assert.Equal(flags, coin.OutpointFlags);
        }

        [Fact]
        public void AppendEvents()
        {
            var buffer = new byte[4096];
            var coin = new Coin(buffer);

            Assert.Equal(0, coin.Events.Length);

            var events = new[]
            {
                new CoinEvent(new BlockAlias(12, 0), CoinEventKind.Production),
                new CoinEvent(new BlockAlias(14, 2), CoinEventKind.Consumption),
            };

            coin.SetEvents(events);

            Assert.True(events.SequenceEqual(coin.Events.ToArray()));
        }
    }
}
