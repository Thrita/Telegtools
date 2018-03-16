using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace Thrita.Telegtools.EntityFramework
{
    internal class TelegramPostConfig : EntityTypeConfiguration<TelegramPost>
    {
        public TelegramPostConfig()
        {
            HasKey(tp => tp.TelegramPostId);

            Property(tp => tp.Id)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
                    new IndexAttribute("IX_TelegramPost_ID", 1) { IsUnique = false }));

            Property(tp => tp.PossibleTitle)
                .HasMaxLength(WebChannelTools.MAX_TITLE_LENGTH);

            Property(tp => tp.Author)
                .HasMaxLength(255);

            Property(tp => tp.ChannelName)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
                    new IndexAttribute("IX_TelegramPost_ChannelName", 1) { IsUnique = false }));

            Property(tp => tp.DateString)
                .HasMaxLength(75);

            Property(tp => tp.ViewCount)
                .HasMaxLength(50);

            Property(tp => tp.ReadDate)
                .IsRequired();

            Ignore(tp => tp.AttachmentUri);
        }
    }
}