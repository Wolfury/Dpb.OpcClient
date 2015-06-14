namespace Dpb.OpcClient.Impl
{
    using System.Collections.Generic;
    using Dpb.OpcClient;

    public class SynchronizedOpcClient : IOpcClient
    {
        private readonly IOpcClient baseClient;

        private readonly object syncRoot = new object();

        public SynchronizedOpcClient(IOpcClient baseClient)
        {
            this.baseClient = baseClient;
        }

        public void Dispose()
        {
            lock (this.syncRoot)
            {
                this.baseClient.Dispose();
            }
        }

        public IOpcWriteBatch CreateWriteBatch()
        {
            lock (this.syncRoot)
            {
                return new SynchronizedWriteBatch(this.baseClient.CreateWriteBatch(), this.syncRoot);
            }
        }

        public IList<OpcReading> ReadValues(IList<string> tags, bool throwOnBad = true)
        {
            lock (this.syncRoot)
            {
                return this.baseClient.ReadValues(tags, throwOnBad);
            }
        }

        public void SubscribeToTagChange(int publishingInterval, string tagName, object clientHandle, TagValueChanged callback)
        {
            lock (this.syncRoot)
            {
                this.baseClient.SubscribeToTagChange(publishingInterval, tagName, clientHandle, callback);
            }
        }

        private class SynchronizedWriteBatch : IOpcWriteBatch
        {
            private readonly object syncRoot;

            private readonly IOpcWriteBatch batch;

            public SynchronizedWriteBatch(IOpcWriteBatch batch, object syncRoot)
            {
                this.syncRoot = syncRoot;
                this.batch = batch;
            }

            public void Dispose()
            {
                lock (this.syncRoot)
                {
                    this.batch.Dispose();
                }
            }

            public void Write(string tagName, object tagValue)
            {
                lock (this.syncRoot)
                {
                    this.batch.Write(tagName, tagValue);
                }
            }

            public void Commit()
            {
                lock (this.syncRoot)
                {
                    this.batch.Commit();
                }
            }
        }
    }
}