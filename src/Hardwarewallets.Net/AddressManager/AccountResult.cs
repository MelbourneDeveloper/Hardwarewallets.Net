using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hardwarewallets.Net.Addresses
{
    public class AccountResult
    {
        public uint AccountNumber { get; }
        public IList<PathInformation> ChangeAddresses { get; } = new Collection<PathInformation>();
        public IList<PathInformation> Addresses { get; } = new Collection<PathInformation>();

        public AccountResult(uint accountNumber, IList<PathInformation> addresses, IList<PathInformation> changeAddresses)
        {
            AccountNumber = accountNumber;
            ChangeAddresses = changeAddresses;
            Addresses = addresses;
        }
    }
}
