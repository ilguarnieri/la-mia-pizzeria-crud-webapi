using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    [Table("pizzas")]
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column("name")]
        [StringLength(80, ErrorMessage = "Il nome può avere massimo 80 caratteri")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column("ingredients", TypeName = "text")]
        public string Ingredients { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [Column("price", TypeName = "decimal(5,2)")]
        [Range(1,30, ErrorMessage =  "Inserisci un prezzo valido")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }



        public Pizza()
        {

        }

        public Pizza(string name, string ingredients, string photo, decimal price)
        {
            this.Name = name;
            this.Ingredients = ingredients;
            this.Photo = photo;
            this.Price = price;
        }

    }
}
