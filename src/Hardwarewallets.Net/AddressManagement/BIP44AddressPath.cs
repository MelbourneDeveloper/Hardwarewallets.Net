﻿using Hardwarewallets.Net.Model;
using System;

namespace Hardwarewallets.Net.AddressManagement
{
    public class BIP44AddressPath : AddressPathBase, IBIP44AddressPath
    {
        public uint Purpose => Validate() ? AddressPathElements[0].Value : 0;

        public uint CoinType => Validate() ? AddressPathElements[1].Value : 0;

        public uint Account => Validate() ? AddressPathElements[2].Value : 0;

        public uint Change => Validate() ? AddressPathElements[3].Value : 0;

        public uint AddressIndex => Validate() ? AddressPathElements[4].Value : 0;

        public BIP44AddressPath()
        {
        }

        public bool Validate()
        {
            var errorPrefix = "The address path is not a valid BIP44 Address Path.";
            if (AddressPathElements.Count != 5) throw new Exception($"{errorPrefix} 5 Elements are required but {AddressPathElements.Count} were found.");
            if (!AddressPathElements[0].Harden) throw new Exception($"{errorPrefix} Purpose must be hardened");
            if (AddressPathElements[0].Value != 44 && AddressPathElements[0].Value != 49) throw new Exception($"{errorPrefix} Purpose must 44 or 49");
            if (!AddressPathElements[1].Harden) throw new Exception($"{errorPrefix} Coint Type must be hardened");
            if (!AddressPathElements[2].Harden) throw new Exception($"{errorPrefix} Account must be hardened");
            if (AddressPathElements[3].Harden) throw new Exception($"{errorPrefix} Change must not be hardened");
            if (AddressPathElements[3].Value != 0 && AddressPathElements[0].Value != 1) throw new Exception($"{errorPrefix} Change must 0 or 1");
            if (AddressPathElements[4].Harden) throw new Exception($"{errorPrefix} Address Index must not be hardened");
            return true;
        }

        public BIP44AddressPath(bool isSegwit, uint coinType, uint account, bool isChange, uint addressIndex)
        {
            AddressPathElements.Add(new AddressPathElement { Value = isSegwit ? (uint)49 : 44, Harden = true });
            AddressPathElements.Add(new AddressPathElement { Value = coinType, Harden = true });
            AddressPathElements.Add(new AddressPathElement { Value = account, Harden = true });
            AddressPathElements.Add(new AddressPathElement { Value = isChange ? 1 : (uint)0, Harden = false });
            AddressPathElements.Add(new AddressPathElement { Value = addressIndex, Harden = false });
        }
    }
}
