using System;
using System.Collections.Generic;
using System.Text;

namespace Hardwarewallets.Net.Model
{
    public interface IAddressPathElement
    {
        uint UnhardenedValue { get; }
        bool Harden { get; }
    }
}
