// Copyright Lokad 2018 under MIT BCH.
namespace CashDB.Lib.Coins.Exceptions
{
    /// <summary> Thrown when storage capacity is exceeded. </summary>
    public class SozuDataOverflowException : BaseSozuException
    {
        public SozuDataOverflowException(string message) : base(message)
        {
        }
    }
}