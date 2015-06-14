namespace Dpb.OpcClient.Impl
{
    //public class OpcClientFactory
    //{
    //    private readonly Func<IOpcClient> clientFactoryMethod;

    //    private readonly Queue<IOpcClient> availableClients = new Queue<IOpcClient>();

    //    private readonly object syncRoot = new object();

    //    private int createdCount;

    //    public OpcClientFactory()
    //        : this(() => new DefaultOpcClient())
    //    {

    //    }

    //    public OpcClientFactory(Func<IOpcClient> clientFactoryMethod)
    //    {
    //        this.clientFactoryMethod = clientFactoryMethod;
    //    }

    //    public IOpcClient Create()
    //    {
    //        lock (this.syncRoot)
    //        {
    //            if (this.availableClients.Count == 0)
    //            {
    //                this.availableClients.Enqueue(this.clientFactoryMethod());
    //            }

    //            return new SynchronizedOpcClient(new ConnectionPoolOpcClientWrapper(this.availableClients.Dequeue(), this));
    //        }
    //    }

    //    private void ReturnOpcClientToPool(IOpcClient client)
    //    {
    //        lock (this.syncRoot)
    //        {
    //            this.availableClients.Enqueue(client);
    //        }
    //    }

    //    private class ConnectionPoolOpcClientWrapper : IOpcClient
    //    {
    //        private readonly IOpcClient baseClient;

    //        private readonly OpcClientFactory factory;

    //        public ConnectionPoolOpcClientWrapper(IMrpOpcClient baseClient, ConnectionPoolOpcClientFactory factory)
    //        {
    //            this.baseClient = baseClient;
    //            this.factory = factory;
    //        }

    //        public void Dispose()
    //        {
    //            this.factory.ReturnOpcClientToPool(this.baseClient);
    //        }

    //        public IOpcWriteBatch CreateWriteBatch()
    //        {
    //            return this.baseClient.CreateWriteBatch();
    //        }

    //        public IList<string> ReadValues(IList<string> tags)
    //        {
    //            return this.baseClient.ReadValues(tags);
    //        }

    //        public void SubscribeToTagChange(int publishingInterval, string tagName, object clientHandle, TagValueChanged callback)
    //        {
    //            this.baseClient.SubscribeToTagChange(publishingInterval, tagName, clientHandle, callback);
    //        }
    //    }
    //}
}