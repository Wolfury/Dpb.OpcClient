namespace Dpb.OpcClient
{
    using System;
    using System.Collections.Generic;

    public delegate void TagValueChanged(string tagName, object tagValue, object clientHandle);

    public interface IOpcClient : IDisposable
    {
        IOpcWriteBatch CreateWriteBatch();

        IList<OpcReading> ReadValues(IList<string> tags, bool throwOnBad = true);

        void SubscribeToTagChange(int publishingInterval, string tagName, object clientHandle, TagValueChanged callback);
    }
}