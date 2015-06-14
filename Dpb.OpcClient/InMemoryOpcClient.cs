namespace Dpb.OpcClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryOpcClient : IOpcClient
    {
        private readonly Dictionary<string, object> currentValues = new Dictionary<string, object>();

        private readonly Dictionary<string, List<Action>> callbacks = new Dictionary<string, List<Action>>();

        public void Dispose()
        {
        }

        public IOpcWriteBatch CreateWriteBatch()
        {
            return new InMemoryWriteBatch(this);
        }

        public IList<OpcReading> ReadValues(IList<string> tags, bool throwOnBad = true)
        {
            var readings = tags
                .Select(x => new OpcReading
                {
                    IsGood = this.currentValues.ContainsKey(x),
                    TagName = x,
                    Value = this.currentValues.ContainsKey(x) ? this.currentValues[x] : null
                })
                .ToList();

            if (readings.Any(x => !x.IsGood))
            {
                throw new OpcClientException("One or more bad readings");
            }

            return readings;
        }

        public void SubscribeToTagChange(int publishingInterval, string tagName, object clientHandle, TagValueChanged callback)
        {
            if (!this.callbacks.ContainsKey(tagName))
            {
                this.callbacks.Add(tagName, new List<Action>());
            }

            this.callbacks[tagName].Add(() =>
            {
                callback(tagName, clientHandle, this.currentValues[tagName]);
            });
        }

        public void WriteValue(string tagName, object value)
        {
            var isChanged = !this.currentValues.ContainsKey(tagName) || this.currentValues[tagName] != value;
            this.currentValues[tagName] = value;

            if (this.callbacks.ContainsKey(tagName) && isChanged)
            {
                foreach (var action in this.callbacks[tagName])
                {
                    action();
                }
            }
        }

        private class InMemoryWriteBatch : IOpcWriteBatch
        {
            private readonly Dictionary<string, object> valuesToWrite = new Dictionary<string, object>();

            private readonly InMemoryOpcClient opcClient;

            public InMemoryWriteBatch(InMemoryOpcClient opcClient)
            {
                this.opcClient = opcClient;
            }

            public void Dispose()
            {
            }

            public void Write(string tagName, object tagValue)
            {
                if (this.valuesToWrite.ContainsKey(tagName))
                {
                    return;
                }

                this.valuesToWrite.Add(tagName, tagValue);
            }

            public void Commit()
            {
                foreach (var o in this.valuesToWrite)
                {
                    this.opcClient.WriteValue(o.Key, o.Value);
                }
            }
        }
    }
}