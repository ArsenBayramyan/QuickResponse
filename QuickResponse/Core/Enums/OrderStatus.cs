using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickResponse.Core.Enums
{
    public enum OrderStatus:byte
    {
        AwaitingApproval=1,
        Approved,
        Canceled,
        Completed
    }
}
