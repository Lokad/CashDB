// Copyright Lokad 2018 under MIT BCH.
using System.Runtime.InteropServices;

namespace CashDB.Lib.Messaging.NativeClient
{
    internal static partial class PInvokes
    {
        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_initialize();

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_shutdown();

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_connect([MarshalAs(UnmanagedType.LPStr)] string cnxString,
            out SafeConnectionHandle connectionHandle);

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_disconnect(SafeConnectionHandle connectionHandle,
            [MarshalAs(UnmanagedType.LPStr)] string reason);


        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_utxo_open_block(
            SafeConnectionHandle connection,
            ref CommittedBlockId parentId,
            out BlockHandle handle,
            ref UncommittedBlockId ucid);

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_utxo_commit_block(
            SafeConnectionHandle connection,
            BlockHandle handle,
            ref CommittedBlockId blockId);

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_utxo_get_committed_block(
            SafeConnectionHandle connection,
            ref CommittedBlockId blockId,
            out BlockHandle handle);

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_utxo_get_uncommitted_block(
            SafeConnectionHandle connection,
            ref UncommittedBlockId blockUcid,
            out BlockHandle handle);

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern ReturnCode cashdb_utxo_get_blockinfo(
            SafeConnectionHandle connection,
            BlockHandle handle,
            ref BlockInfo info);

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe ReturnCode cashdb_utxo_get_coins(
            SafeConnectionHandle connection,
            BlockHandle context,
            int coinLength,
            Coin* coins,
            int storageLength,
            byte* storage
        );

        [DllImport("cashdbclient", CallingConvention = CallingConvention.Cdecl)]
        internal static extern unsafe ReturnCode cashdb_utxo_set_coins(
            SafeConnectionHandle connection,
            BlockHandle context,
            int coinLength,
            Coin* coins,
            int storageLength,
            byte* storage
        );
    }
}