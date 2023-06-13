using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.Assignment
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string? AssetCode { get; set; }
        public string? AssetName { get; set; }
        public string? SpecifiCation { get; set; }
        public string AssignedToUser { get; set; }
        public string AssignedByUser { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Note { get; set; }
        public AssignmentStateEnumDto AssignmentState { get; set; }
        public string LocationId { get; set; }
        public string? CategoryName { get; set; }
        public string? FullName { get; set; }
    }
}
