namespace Dpb.OpcClient
{
    using System;

    public class OpcClientException : Exception
    {
        public OpcClientException(string message)
            : base(message)
        {
        }
    }
}