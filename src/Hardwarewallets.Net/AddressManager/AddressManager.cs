using Hardwarewallets.Net.Base;
using System.Collections.Generic;

namespace Hardwarewallets.Net
{
    public class AddressManager
    {
        #region Public Properties
        public IHardwarewalletManager HardwarewalletManager { get; }
        private uint Purpose { get;  }
        private uint CoinType { get; }
        private IEnumerable<uint> Accounts { get; }
        #endregion

        #region Constructor

        public AddressManager(IHardwarewalletManager hardwarewalletManager)
        {
            HardwarewalletManager = hardwarewalletManager;
        }

        public AddressManager(IHardwarewalletManager hardwarewalletManager, bool isSegit, uint cointType, IEnumerable<uint> accounts) : this(hardwarewalletManager)
        {
            Purpose = isSegit ? (uint)49 : 44;
            CoinType = cointType;
            Accounts = accounts;
        }
        #endregion

        public GetAddressesResult GetAddressesAsync(uint startIndex, int numberOfAddresses, bool includeChangeAddresses, bool includePublicKeys)
        {

        }
    }
}
