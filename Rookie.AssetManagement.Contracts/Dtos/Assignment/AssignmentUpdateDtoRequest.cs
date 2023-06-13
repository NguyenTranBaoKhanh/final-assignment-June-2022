﻿using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.Assignment
{
    public class AssignmentUpdateDtoRequest
    {
        public string StaffCode { get; set; }
        public string AssetCode { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
    }
}
