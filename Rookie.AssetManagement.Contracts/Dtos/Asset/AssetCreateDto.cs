using System;

using System.ComponentModel.DataAnnotations;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.Contracts.Dtos.Asset
{
    public class AssetCreateDto
    {
        [Required]
        public string AssetName { get; set; }
        [Required]
        public string Specification { get; set; }
        [Required]
        public DateTime InstalledDay { get; set; }
        [Required]
        public string CategoryID { get; set; }
        [Required]
        public AssetStateEnumDto AssetState { get; set; }
        public string LocationID { get; set; }
    }
}

