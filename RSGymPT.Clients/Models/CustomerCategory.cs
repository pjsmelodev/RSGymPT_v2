using System.ComponentModel.DataAnnotations;

namespace RSGymPT.Clients.Models
{
    public class CustomerCategory
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}