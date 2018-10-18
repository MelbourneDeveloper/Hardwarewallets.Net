using Hardwarewallets.Net.Model;
using System.Numerics;

namespace Hardwarewallets.Net.Ethereum
{

    /// Information from:
    /// https://web3j.readthedocs.io/en/stable/transactions.html
    /// https://medium.com/@codetractio/inside-an-ethereum-transaction-fa94ffca912f
    /// https://etherscan.io/tx/0x8dd939167a80d45749b0f71f16f063da72f927e3d0792a95d4ac36396d6b197e
    /// Trezor.Net
    /// <summary>
    /// An Ethereum transaciton for signing
    /// </summary>
    public interface IEthereumTransaction
    {
        /// <summary>
        /// Number of outgoing transactions
        /// </summary>
        int Nonce { get; }
        /// <summary>
        /// Gas price in ETH
        /// </summary>
        decimal GasPrice { get; }
        /// <summary>
        /// Gas limit in ETH
        /// </summary>
        decimal GasLimit { get; set; }
        /// <summary>
        /// The account the transaction is sent to
        /// </summary>
        string To { get; }
        /// <summary>
        /// Value in ETH
        /// </summary>
        decimal Value { get; }
        /// <summary>
        /// The address path to derive the address from which the wallet will move the funds from
        /// </summary>
        IAddressPath From { get; }
        /// <summary>
        /// The Ethereum chain/network
        /// </summary>
        int ChainId { get; }
    }
}
