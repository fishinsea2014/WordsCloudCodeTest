using System;
using System.Collections.Generic;
using System.Text;

namespace Jason.Common.Helper
{
    interface ISaltHashHelper
    {
        HashSalt GenerateSaltedHash(int size, string str);
        bool VerifyStr(string inputStr, HashSalt data);
    }
}
