namespace Hardwarewallets.Net.Base.Ethereum
{
    public interface IEthereumTransaction : ITransaction
    {
        uint ChainId { get; }
        long GasPrice { get; }
        long GasLimit { get; }
        string Nonce { get; }
    }
}
