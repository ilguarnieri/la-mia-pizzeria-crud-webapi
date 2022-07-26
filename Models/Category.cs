using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Il nome non può avere più di 50 caratteri")]
        public string Name { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
