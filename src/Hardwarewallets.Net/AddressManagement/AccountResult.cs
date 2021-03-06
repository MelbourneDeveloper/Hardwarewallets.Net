﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hardwarewallets.Net.AddressManagement
{
    public class AccountResult
    {
        public uint AccountNumber { get; }
        public IList<PathResult> ChangeAddresses { get; } = new Collection<PathResult>();
        public IList<PathResult> Addresses { get; } = new Collection<PathResult>();

        public AccountResult(uint accountNumber, IList<PathResult> addresses, IList<PathResult> changeAddresses)
        {
            AccountNumber = accountNumber;
            ChangeAddresses = changeAddresses;
            Addresses = addresses;
        }
    }
}
