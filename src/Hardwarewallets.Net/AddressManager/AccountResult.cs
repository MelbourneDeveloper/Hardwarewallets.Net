using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hardwarewallets.Net
{
    public class AccountResult
    {
        public uint AccountNumber { get; }
        public ICollection<PathInformation> ChangeAddresses { get; } = new Collection<PathInformation>();
        public ICollection<PathInformation> Addresses { get; } = new Collection<PathInformation>();

        public AccountResult(uint accountNumber)
        {
            AccountNumber = accountNumber;
        }
    }
}
