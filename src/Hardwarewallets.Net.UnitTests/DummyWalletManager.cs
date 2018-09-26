﻿using Hardwarewallets.Net.Model;
using Hardwarewallets.Net.UnitTests;
using System;
using System.Threading.Tasks;

namespace Hardwarewallets.Net
{
    public class DummyWalletManager : IAddressDeriver
    {
        public async Task<string> GetAddressAsync(IAddressPath addressPath, bool isPublicKey, bool display)
        {
            if (isPublicKey)
                switch (addressPath.CoinType)
                {
                    case 0:
                        return "1EdcJ3XAZ1jMHka8kwD6oyMkHuJC5qVu8p";
                    case 60:
                        return "0x3f2dD9850509367b57C900F7e1C5f4F0bfF1014B";
                    default:
                        throw new NotImplementedException();
                }
            else
                switch (addressPath.CoinType)
                {
                    case 0:
                        return "02a1633cafcc01ebfb6d78e39f687a1f0995c62fc95f51ead10a02ee0be551b5dc";
                    case 60:
                        return "0x3f2dD9850509367b57C900F7e1C5f4F0bfF1014Bf4F0bfF1014B";
                    default:
                        throw new NotImplementedException();
                }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<T2> SignTransaction<T, T2>(T transaction)
            where T : ITransaction
            where T2 : ISignedTransaction
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (transaction is DummyEthereumTransaction)
            {
                var signedTransaction = new DummySignedEthereumTransaction();
                return (T2)(ISignedTransaction)signedTransaction;
            }

            throw new NotImplementedException();
        }
    }
}
