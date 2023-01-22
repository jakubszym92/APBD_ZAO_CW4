using System.ComponentModel.DataAnnotations;

namespace APBD_ZAO_CW4.Model
{
    public class Animal
    {
        [Required(ErrorMessage = "IdAnimal cannot be null")]
        public int IdAnimal { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Category cannot be null")]
        public string Category { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Area cannot be null")]
        public string Area { get; set; }
    }
}
