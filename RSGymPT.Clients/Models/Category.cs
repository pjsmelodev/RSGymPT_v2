using System.ComponentModel.DataAnnotations;

namespace RSGymPT.Clients.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public ICollection<CustomerCategory> CustomerCategories { get; set; } = new List<CustomerCategory>();
    }
}