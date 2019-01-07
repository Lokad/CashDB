// Copyright Lokad 2018 under MIT BCH.
using System;

namespace CashDB.Lib.Messaging.NativeClient
{
    public class CashDBException : ApplicationException
    {
        public ReturnCode ReturnCode { get; private set; }

        public CashDBException(string message, ReturnCode code) : base(message)
        {
            ReturnCode = code;
        }
    }
}