using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeEstoque.Models{
    public class Product{
        [Key()]
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(60)]
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int Quantity { get; set; }

    }

}