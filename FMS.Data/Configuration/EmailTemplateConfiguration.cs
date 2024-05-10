using FMS.Model;
using System.Data.Entity.ModelConfiguration;

namespace FMS.Data.Configuration
{
    public class EmailTemplateConfiguration : EntityTypeConfiguration<EmailTemplate>
    {
        public EmailTemplateConfiguration()
        {
            ToTable("MstEmailTemplate");


            HasKey<int>(k => k.Id);


            Property(e => e.TemplateName)
                .HasMaxLength(50)
                .IsUnicode(false);


            Property(e => e.Subject)
                .HasMaxLength(250)
                .IsUnicode(false);


            Property(e => e.Body)
                .HasMaxLength(5000)
                .IsUnicode(false);


            HasMany(e => e.Notifications)
                .WithOptional(e => e.EmailTemplate)
                .HasForeignKey<int?>(e => e.EmailTemplateId);

        }

    }
}
