namespace Dpb.OpcClient
{
    using System;

    public interface IOpcWriteBatch : IDisposable
    {
        void Write(string tagName, object tagValue);

        void Commit();
    }
}
