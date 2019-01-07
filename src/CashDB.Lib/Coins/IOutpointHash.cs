// Copyright Lokad 2018 under MIT BCH.
using CashDB.Lib.Messaging;

namespace CashDB.Lib.Coins
{
    /// <summary>
    /// Abstraction of a hash function with a predefined secret.
    /// It protected CashDB against non trivial denial-of-service attack.
    /// </summary>
    public interface IOutpointHash
    {
        ulong Hash(ref Outpoint outpoint);
    }
}
