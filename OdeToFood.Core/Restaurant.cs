using OdeToFood.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OdeToFood.Entities
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "the field Cuisine cannot be left empty.")]
        public CuisineType Cuisine { get; set; }
    }
}
