using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Rookie.AssetManagement.DataAccessor.Entities.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(x => x.AssetCode);
            builder.HasOne(x => x.Category).WithMany(x => x.Assets).HasForeignKey(x => x.CategoryID);
            builder.HasOne(x => x.Location).WithMany(x => x.Assets).HasForeignKey(x => x.LocationID);
            builder.Property(x => x.AssetCode).HasMaxLength(10);
        }
    }
}