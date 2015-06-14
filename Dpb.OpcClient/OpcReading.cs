namespace Dpb.OpcClient
{
    public class OpcReading
    {
        public string TagName { get; set; }

        public object Value { get; set; }

        public bool IsGood { get; set; }
    }
}