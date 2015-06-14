namespace Dpb.OpcClient
{
    using System;
    using System.Collections.Generic;
    using Impl;

    public class DefaultOpcClient : IOpcClient
    {
        //private readonly IOpcClient opcClient;

        private readonly Dictionary<int, OpcSubscription> subscriptions = new Dictionary<int, OpcSubscription>();

        private readonly Dictionary<Guid, object> eventValues = new Dictionary<Guid, object>();

        public DefaultOpcClient()
        {
            //this.opcClient = opcClient;
        }

        public void Dispose()
        {
            //this.opcClient.Dispose();
        }

        public IOpcWriteBatch CreateWriteBatch()
        {
            throw new NotImplementedException();
            //return new WriteBatch(this.opcClient);
        }

        public IList<OpcReading> ReadValues(IList<string> tags, bool throwOnBad = true)
        {
            throw new NotImplementedException();
            //var nodes = new NodeIdCollection(tags.Select(x => new NodeId(x)));
            //DataValueCollection values;

            //this.opcClient.ReadValues(nodes, out values);

            //if (values.Select(x => x.StatusCode).Any(StatusCode.IsBad))
            //{
            //    throw new Exception(StatusCode.LookupSymbolicId(values.Select(x => x.StatusCode).First(StatusCode.IsBad).Code));
            //}

            //return values.Select(x => (x.Value ?? string.Empty).ToString()).ToList();
        }

        public void SubscribeToTagChange(int publishingInterval, string tagName, object clientHandle, TagValueChanged callback)
        {
            throw new NotImplementedException();
            //if (!this.subscriptions.ContainsKey(publishingInterval))
            //{
            //    this.subscriptions.Add(publishingInterval, this.opcClient.AddSubscription(publishingInterval));
            //}

            //object serverHandle;
            //var eventKey = Guid.NewGuid();

            //this.subscriptions[publishingInterval].AddDataMonitoredItem(
            //    new NodeId(tagName),
            //    clientHandle,
            //    (o, dv) =>
            //    {
            //        if (!StatusCode.IsGood(dv.StatusCode))
            //        {
            //            // ignore all not good changes
            //            return;
            //        }

            //        lock (this.eventValues)
            //        {
            //            // First Event occurance of every tag should be ignored                        
            //            if (!this.eventValues.ContainsKey(eventKey))
            //            {
            //                this.eventValues.Add(eventKey, dv.Value);
            //                return;
            //            }

            //            var previousValue = this.eventValues[eventKey];
            //            var currentValue = dv.Value;

            //            // Raise event only if values are truly different
            //            if (Equals(previousValue, currentValue))
            //            {
            //                return;
            //            }

            //            this.eventValues[eventKey] = dv.Value;
            //        }

            //        callback(o, dv.Value);
            //    },
            //    (uint)publishingInterval,
            //    out serverHandle);
        }

        //private class WriteBatch : IOpcWriteBatch
        //{
        //    private readonly NodeIdCollection nodes = new NodeIdCollection();

        //    private readonly DataValueCollection values = new DataValueCollection();

        //    private readonly IOpcClient opcClient;

        //    private bool isDisposed;

        //    public WriteBatch(IOpcClient opcClient)
        //    {
        //        this.opcClient = opcClient;
        //    }

        //    public void Write(string tagName, object tagValue)
        //    {
        //        if (this.isDisposed)
        //        {
        //            throw new ObjectDisposedException("SimpleOpcWriteBatch");
        //        }

        //        if (this.nodes.Any(x => (string)x.Identifier == tagName))
        //        {
        //            MrpLog.Error("Duplicate tag write detected: {0}", tagName);
        //        }

        //        this.nodes.Add(new NodeId(tagName));
        //        this.values.Add(new DataValue(new Variant(Convert.ChangeType(tagValue, typeof(string)))));
        //    }

        //    public void Commit()
        //    {
        //        if (this.isDisposed)
        //        {
        //            throw new ObjectDisposedException("SimpleOpcWriteBatch");
        //        }

        //        if (this.nodes.Count == 0)
        //        {
        //            return;
        //        }

        //        var sw = Stopwatch.StartNew();

        //        StatusCodeCollection results;
        //        this.opcClient.WriteValues(this.nodes, this.values, out results);

        //        if (results.Any(StatusCode.IsBad))
        //        {
        //            throw new Exception(StatusCode.LookupSymbolicId(results.First(StatusCode.IsBad).Code));
        //        }

        //        sw.Stop();
        //        MrpLog.Info("Batch of {0} values saved to PLC in {1}", this.nodes.Count, sw.Elapsed);
        //    }

        //    public void Dispose()
        //    {
        //        this.isDisposed = true;
        //    }
        //}
    }
}