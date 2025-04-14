using System.ComponentModel.DataAnnotations;

namespace RSGymPT.Clients.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        public bool IsFidelized { get; set; }
        public ICollection<CustomerCategory> CustomerCategories { get; set; } = new List<CustomerCategory>();
    }
}