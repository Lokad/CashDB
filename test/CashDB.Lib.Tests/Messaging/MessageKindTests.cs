// Copyright Lokad 2018 under MIT BCH.
using System;
using System.Linq;
using CashDB.Lib.Messaging;
using Xunit;

namespace CashDB.Lib.Tests.Messaging
{
    public class MessageKindTests
    {
        private readonly MessageKind[] _allKinds = Enum.GetValues(typeof(MessageKind)).Cast<MessageKind>().ToArray();

        [Fact]
        public void CheckIsDefined()
        {
            Assert.All(_allKinds, kind => Assert.True(kind.IsDefined()));
        }

        [Fact]
        public void CheckIsForCoinController()
        {
            Assert.Equal(8, _allKinds.Count(kind => kind.IsForCoinController()));
        }

        [Fact]
        public void CheckIsResponse()
        {
            Assert.False(MessageKind.CommitBlock.IsResponse());
            Assert.True(MessageKind.CommitBlockResponse.IsResponse());
        }
    }
}