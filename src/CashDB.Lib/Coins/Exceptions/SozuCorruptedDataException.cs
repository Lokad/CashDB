// Copyright Lokad 2018 under MIT BCH.
namespace CashDB.Lib.Coins.Exceptions
{
    /// <summary> Thrown when the data storage appears corrupted. </summary>
    public class SozuCorruptedDataException : BaseSozuException
    {
        internal SozuCorruptedDataException(string message) : base(message)
        {
        }
    }
}