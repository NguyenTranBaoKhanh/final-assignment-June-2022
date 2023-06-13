using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities.Enums
{
    public enum AssetState
    {
        [Description("Available")]
        Available = 1,
        [Description("Assigned")]
        Assigned = 2,
        [Description("Waiting for recycling")]
        Waiting = 3,
        [Description("Recycled")]
        Recycled = 4,
        [Description("Not Available")]
        NotAvailable = 5,
    }
}
