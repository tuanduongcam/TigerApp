using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EventManager.DataModel.Models.Mapping
{
    public class UserGiftRedeemMap : EntityTypeConfiguration<UserGiftRedeem>
    {
		public UserGiftRedeemMap()
        {
            // Primary Key
            this.HasKey(t => t.UserGiftRedeemID);

            // Properties
			//this.Property(t => t.UserId)
			//	.IsRequired()
			//	.HasMaxLength(128);

            // Table & Column Mappings
			this.ToTable("UserGiftRedeem");
			this.Property(t => t.UserGiftRedeemID).HasColumnName("UserGiftRedeemID");
            this.Property(t => t.UserId).HasColumnName("UserId");
			this.Property(t => t.GiftID).HasColumnName("GiftID");
			this.Property(t => t.Point).HasColumnName("Point");
			this.Property(t => t.RedeemDate).HasColumnName("RedeemDate");
			this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
			this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            // Relationships
			this.HasRequired(t => t.AspNetUser)
				.WithMany(t => t.UserGiftRedeems)
				.HasForeignKey(d => d.UserId);
			this.HasRequired(t => t.Gift)
                .WithMany(t => t.UserGiftRedeems)
                .HasForeignKey(d => d.GiftID);

        }
    }
}
