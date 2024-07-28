using System.ComponentModel.DataAnnotations;

namespace HomeWork2.Models
{
    public class ProductAddViewModel
    {

        [Required(ErrorMessage = "Name is required")]
        [MinLength(4, ErrorMessage = "Should be more than 4 letters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(6, ErrorMessage = "Should be more than 6 letters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 1000, ErrorMessage = "Should be more than 0")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        [Range(0, 100, ErrorMessage = "Should be between 0-100")]
        public int Discount { get; set; }

    }
}
