using System.Numerics;

namespace Hardwarewallets.Net.Base.Ethereum
{
    public interface IEthereumTransaction : ITransaction
    {
        uint ChainId { get; }
        BigInteger GasPrice { get; }
        BigInteger GasLimit { get; }
        BigInteger Nonce { get; }
        byte[] Data { get; }
    }
}
