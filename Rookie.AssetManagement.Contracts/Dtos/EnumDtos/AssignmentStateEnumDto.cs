using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.EnumDtos
{
    public enum AssignmentStateEnumDto
    {
        [Description("Accepted")]
        Accepted = 1,
        [Description("Waiting for acceptance")]
        Waiting = 2,
        [Description("Waiting for retunring")]
        WaitingReturn = 3,
        [Description("Declined")]
        Declined = 4,
    }
}
