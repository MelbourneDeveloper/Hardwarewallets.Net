namespace Hardwarewallets.Net.AddressManagement
{
    public class PathResult
    {
        string PublicKey { get; }
        string Address { get; }

        public PathResult(string publicKey, string address)
        {
            PublicKey = publicKey;
            Address = address;
        }
    }
}
