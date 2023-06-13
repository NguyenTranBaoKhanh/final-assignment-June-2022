using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Enums
{
    public enum RequestState
    {
        [Description("Completed")]
        Completed = 1,
        [Description("Waiting for returning")]
        Waiting = 2
    }
}
