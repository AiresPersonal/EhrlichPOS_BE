using System.ComponentModel.DataAnnotations;

namespace EhrlichPOS_BE.Dto
{
    public class ErrorResponse
    {
        [Required]
        public string? Code { get; set; }

        [Required]
        public string? Message { get; set; }
    }
}
