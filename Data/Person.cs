using System.ComponentModel.DataAnnotations;

namespace JsGrid.Data
{
    public class Person
    {
        [Key]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool Married { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}
