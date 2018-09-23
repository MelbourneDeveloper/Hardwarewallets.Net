namespace Hardwarewallets.Net.Addresses
{
    public class PathInformation
    {
        string PublicKey { get; }
        string Address { get; }

        public PathInformation(string publicKey, string address)
        {
            PublicKey = publicKey;
            Address = address;
        }
    }
}
