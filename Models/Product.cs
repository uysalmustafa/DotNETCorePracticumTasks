using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Please enter Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Product Name")]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Please enter Product Price")]
        public decimal ProductPrice { get; set; }

    }
}
