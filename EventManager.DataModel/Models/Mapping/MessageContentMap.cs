using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EventManager.DataModel.Models.Mapping
{
    public class MessageContentMap : EntityTypeConfiguration<MessageContent>
    {
		public MessageContentMap()
        {
            // Primary Key
			this.HasKey(t => t.MessageContentID);

            // Properties
			this.Property(t => t.Sender);
			this.Property(t => t.Receiver)
                .IsRequired()
				.HasMaxLength(200);

            // Table & Column Mappings
			this.ToTable("MessageContent");
			this.Property(t => t.MessageContentID).HasColumnName("MessageContentID");
			this.Property(t => t.ServiceTypeID).HasColumnName("ServiceTypeID");
			this.Property(t => t.BodyMessage)
				.IsRequired()
				.HasMaxLength(500);
			this.Property(t => t.Status).HasColumnName("Status");
			this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
			this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");

        }
    }
}
