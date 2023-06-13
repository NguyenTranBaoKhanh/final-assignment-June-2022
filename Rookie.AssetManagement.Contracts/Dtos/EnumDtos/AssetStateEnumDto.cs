using System;
using System.ComponentModel;

namespace Rookie.AssetManagement.Contracts.Dtos.EnumDtos
{
    public enum AssetStateEnumDto
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

