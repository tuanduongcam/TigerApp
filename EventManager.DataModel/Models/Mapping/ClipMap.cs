using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EventManager.DataModel.Models.Mapping
{
    public class ClipMap : EntityTypeConfiguration<Clip>
    {
		public ClipMap()
        {
            // Primary Key
            this.HasKey(t => t.ClipID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

			this.Property(t => t.UserId)
			  .IsRequired()
			  .HasMaxLength(128);
            // Table & Column Mappings
            this.ToTable("Clip");
			this.Property(t => t.ClipID).HasColumnName("ClipID");
            this.Property(t => t.Name).HasColumnName("Name");
			this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.ClipPath).HasColumnName("ClipPath");
			this.Property(t => t.Approval).HasColumnName("Approval");
			this.Property(t => t.ApprovedBy).HasColumnName("ApprovedBy");
			this.Property(t => t.Tag).HasColumnName("Tag");
			this.Property(t => t.NoView).HasColumnName("NoView");
			this.Property(t => t.Point).HasColumnName("Point");
			this.HasRequired(t => t.AspNetUser)
			   .WithMany(t => t.Clips)
			   .HasForeignKey(d => d.UserId);
        }
    }
}
