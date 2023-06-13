using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rookie.AssetManagement.DataAccessor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.DataAccessor.Entities.Configurations
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.AcceptedUser).WithMany(x => x.AcceptedRequests)
                    .HasForeignKey(x => x.AcceptedUserId);
            builder.HasOne(x => x.RequestedUser).WithMany(x => x.CreatedRequests)
                    .HasForeignKey(x => x.RequestedUserId);
            builder.Property(x => x.RequestState).HasDefaultValue(RequestState.Waiting);
        }
    }
}
