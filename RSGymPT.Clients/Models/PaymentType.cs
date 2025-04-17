using System.ComponentModel.DataAnnotations;

namespace RSGymPT.Clients.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentTypeName { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The amount must be greater than 0.")]
        public decimal Amount { get; set; }
    }
}