using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Contracts.Dtos.Asset
{
    public class AssetUpdateDto
    {
        [Required]
        public string AssetName { get; set; }
        [Required]
        public string Specification { get; set; }
        [Required]
        public DateTime InstalledDay { get; set; }
        [Required]
        public AssetStateEnumDto AssetState { get; set; }
    }
}
