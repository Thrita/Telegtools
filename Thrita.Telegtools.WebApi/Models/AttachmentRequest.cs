using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Thrita.Telegtools.WebApi.Models
{
    public sealed class AttachmentRequest
    {
        [Required, Range(1, int.MaxValue)]
        public int FromId { get; set; }

        [Required, Range(1, int.MaxValue)]
        public int ToId { get; set; }

        public string FtpUrl { get; set; }

        public string FtpUser { get; set; }

        public string FtpPassword { get; set; }

        [Required]
        public TelegramPostType[] Types { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (ToId < FromId)
                results.Add(
                    new ValidationResult(
                        $"The field {nameof(ToId)} must be equal or greater than the field {nameof(FromId)}.",
                        new[] { nameof(ToId) }));

            return results;
        }
    }
}