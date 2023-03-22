using System.ComponentModel.DataAnnotations;

namespace AbbyWeb.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Display Order (max-150)")]
        [Range(1, 150, ErrorMessage = "Display order must be between 1 and 150")]
        public int DisplayOrder { get; set; }
    }
}
