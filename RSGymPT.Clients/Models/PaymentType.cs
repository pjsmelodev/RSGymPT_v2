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
    }
}