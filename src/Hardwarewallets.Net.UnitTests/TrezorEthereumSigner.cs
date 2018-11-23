using Hardwarewallets.Net.Utilities;
using KeepKey.Net.Contracts;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using System;
using System.Threading.Tasks;
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

        public async Task<IEthereumTransactionRequest> SignTransction(IEthereumTransaction transaction)
        {
            var trezorTransaction = new EthereumSignTx
            {
                Nonce = transaction.Nonce.ToBytesForRLPEncoding().ToHex().ToHexBytes(),
                AddressNs = transaction.From.ToArray(),
                ChainId = (uint)transaction.ChainId,
                GasLimit = ((int)transaction.GasLimit).ToBytesForRLPEncoding().ToHex().ToHexBytes(),
                GasPrice = transaction.GasPrice.ToBytesForRLPEncoding().ToHex().ToHexBytes(),
                To = transaction.To.ToHexBytes(),
                Value = transaction.Value.ToHexBytes()
            };

            var asdasd = await TrezorManager.SendMessageAsync<EthereumTxRequest, EthereumSignTx>(trezorTransaction);

            return ToEthereumTransactionRequest(asdasd);
        }

        private IEthereumTransactionRequest ToEthereumTransactionRequest(EthereumTxRequest asdasd)
        {
            throw new NotImplementedException();
        }
    }


}
