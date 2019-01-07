// Copyright Lokad 2018 under MIT BCH.
using System;
using CashDB.Lib.Messaging;

namespace CashDB.Lib.Coins
{
    /// <summary>
    /// Flags for extended properties of an outpoint from the CashDB perspective.
    /// </summary>
    [Flags]
    public enum CashDBOutpointFlags : ushort
    {
        None,
        PersistentIsCoinbase,
    }

    public static class CashDBOutpointFlagsExtensions
    {
        public static OutpointFlags ToClientFlags(this CashDBOutpointFlags _this)
        {
            // Not using 'Enum.HasFlags' to avoid an accidental object allocation.
            if (_this == CashDBOutpointFlags.PersistentIsCoinbase)
                return OutpointFlags.IsCoinbase;

            return OutpointFlags.None;
        }
    }
}