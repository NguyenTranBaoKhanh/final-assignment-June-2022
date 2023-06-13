using System;
using System.Collections.Generic;
using Rookie.AssetManagement.DataAccessor.Entities.Enums;

namespace Rookie.AssetManagement.DataAccessor.Entities
{
    public class Asset
    {
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string Specification { get; set; }
        public DateTime InstalledDay { get; set; }
        public string CategoryID { get; set; }
        public Category Category { get; set; }
        public virtual AssetState AssetState { get; set; }
        public string LocationID { get; set; }
        public virtual Location Location { get; set; }
        public Boolean IsDeleted { get; set; }
        public virtual List<Assignment> Assignments { get; set; }

    }
}
