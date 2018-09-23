using System;
using System.Collections.Generic;
using System.Text;

namespace Hardwarewallets.Net.Base
{
    public interface IAddressPathFactory
    {
        IAddressPath GetAddressPath(uint change, uint account, uint addressIndex);
    }
}
