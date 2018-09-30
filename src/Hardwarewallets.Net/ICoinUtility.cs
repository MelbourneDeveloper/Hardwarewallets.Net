using System;
using System.Collections.Generic;
using System.Text;

namespace Hardwarewallets.Net
{
    public interface ICoinUtility
    {
        uint GetCoinType(string coinShortCut);
        string GetCoinShortcut(uint coinType);
    }
}
