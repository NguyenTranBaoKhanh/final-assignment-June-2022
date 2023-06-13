using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities.Configurations
{
    public class AssignmentCongfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasOne(x => x.AssignedByUser).WithMany(x => x.AssignedBys)
                .HasForeignKey(x => x.AssignedByUserId);
            builder.HasOne(x => x.AssignedToUser).WithMany(x => x.AssignedTos)
                .HasForeignKey(x => x.AssignedToUserId);
            builder.HasOne(x => x.Asset).WithMany(x => x.Assignments)
                .HasForeignKey(x => x.AssetCode);
            builder.HasOne<Request>(x => x.Request).WithOne(x => x.Assignment)
                .HasForeignKey<Request>(x => x.AssignmentId);
        }
    }
}
