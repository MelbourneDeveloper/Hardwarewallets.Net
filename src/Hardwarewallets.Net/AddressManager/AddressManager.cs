using Hardwarewallets.Net.Base;
using System.Collections.Generic;

namespace Hardwarewallets.Net.Addresses
{
    public class AddressManager
    {
        #region Public Properties
        public IHardwarewalletManager HardwarewalletManager { get; }
        private uint Purpose { get; }
        private uint CoinType { get; }
        #endregion

        #region Constructor

        public AddressManager(IHardwarewalletManager hardwarewalletManager)
        {
            HardwarewalletManager = hardwarewalletManager;
        }

        public AddressManager(IHardwarewalletManager hardwarewalletManager, bool isSegit, uint cointType) : this(hardwarewalletManager)
        {
            Purpose = isSegit ? (uint)49 : 44;
            CoinType = cointType;
        }
        #endregion

        public GetAddressesResult GetAddressesAsync(uint startIndex, int numberOfAddresses, int numberOfAccounts, bool includeChangeAddresses, bool includePublicKeys)
        {
            var retVal = new GetAddressesResult();

            for (uint account = 0; account < numberOfAccounts + numberOfAddresses; account++)
            {
                for (uint index = startIndex; index < startIndex + numberOfAddresses; index++)
                {
                    var accountResult = new AccountResult(account);
                }
            }
        }
    }
}
