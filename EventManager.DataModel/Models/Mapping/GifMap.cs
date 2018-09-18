using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EventManager.DataModel.Models.Mapping
{
    public class GifMap : EntityTypeConfiguration<Gift>
    {
		public GifMap()
        {
            // Primary Key
            this.HasKey(t => t.GiftID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Gift");
			this.Property(t => t.GiftID).HasColumnName("GiftID");
            this.Property(t => t.Name).HasColumnName("Name");
			this.Property(t => t.Remark).HasColumnName("Remark");
			this.Property(t => t.Point).HasColumnName("Point");
			this.Property(t => t.FilePath).HasColumnName("FilePath");
        }
    }
}
