using System.ComponentModel.DataAnnotations;

namespace MultiProjectSample.Models.Models
{
    public class CategoryModel : BaseModel
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [MinLength(3, ErrorMessage = "Category Name must be at least 3 characters")]
        [MaxLength(15, ErrorMessage = "Category Name can not be more than 40 characters")]
        public string CategoryName { get; set; }

        [MaxLength(40, ErrorMessage = "Description can not be more than 40 characters")]
        public string Description { get; set; }

        public string Picture { get; set; }
    }
}