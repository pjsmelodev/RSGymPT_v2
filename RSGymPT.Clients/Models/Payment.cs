using System.ComponentModel.DataAnnotations;

namespace RSGymPT.Clients.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}