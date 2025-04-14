using System.ComponentModel.DataAnnotations;

namespace RSGymPT.Clients.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public bool IsFidelized { get; set; }
    }
}