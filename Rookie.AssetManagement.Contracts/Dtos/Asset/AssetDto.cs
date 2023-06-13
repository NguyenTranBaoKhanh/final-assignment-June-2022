using System;
using Rookie.AssetManagement.Contracts.Dtos.EnumDtos;

namespace Rookie.AssetManagement.Contracts.Dtos.Asset
{
    public class AssetDto
    {
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Specification { get; set; }
        public DateTime InstalledDay { get; set; }
        public string CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public AssetStateEnumDto AssetState { get; set; }
        public string LocationID { get; set; }
    }
}

