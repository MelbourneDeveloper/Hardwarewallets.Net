namespace Hardwarewallets.Net.Base.Ethereum
{
    public interface IEthereumTransaction : ITransaction
    {
        uint ChainId { get; }
        decimal GasPrice { get; }
        int GasLimit { get; }
        string Nonce { get; }
    }
}
