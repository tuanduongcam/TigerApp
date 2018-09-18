using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EventManager.DataModel.Models.Mapping
{
    public class AspNetUserImgMap : EntityTypeConfiguration<AspNetUserImg>
    {
		public AspNetUserImgMap()
        {
            // Primary Key
            this.HasKey(t => t.AspNetUserImgID);

            // Properties
            this.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
			this.ToTable("AspNetUserImg");
			this.Property(t => t.AspNetUserImgID).HasColumnName("AspNetUserImgID");
            this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.FilePath).HasColumnName("FilePath");
			this.Property(t => t.IsFearureImg).HasColumnName("IsFearureImg");

            // Relationships
            this.HasRequired(t => t.AspNetUser)
                .WithMany(t => t.AspNetUserImages)
                .HasForeignKey(d => d.UserId);

        }
    }
}
