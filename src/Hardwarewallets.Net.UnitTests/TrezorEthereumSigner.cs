using Hardwarewallets.Net.Utilities;
using KeepKey.Net.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Trezor.Net;

namespace Hardwarewallets.Net.Ethereum
{
    public class TrezorEthereumSigner : IEthereumTransactionSigner
    {
        public TrezorManager TrezorManager { get; }

        public TrezorEthereumSigner(TrezorManager trezorManager)
        {
            TrezorManager = trezorManager;
        }

        public IEthereumTransactionRequest SignTransction(IEthereumTransaction transaction)
        {
            var trezorTransaction = new EthereumSignTx
            {
                Nonce = transaction.Nonce.ToBytesForRLPEncoding().ToHex().ToHexBytes(),
                AddressNs = transaction.From.ToHardenedArray(),
                ChainId = (uint)transaction.ChainId,
                GasLimit = ((int)transaction.GasLimit).ToBytesForRLPEncoding().ToHex().ToHexBytes(),
                GasPrice = transaction.GasPrice.ToBytesForRLPEncoding().ToHex().ToHexBytes(),
                To = transaction.To.ToHexBytes(),
                Value = transaction.Value.ToHexBytes()

            }
        }
    }


}
