using System.ComponentModel.DataAnnotations;

namespace MultiProjectSample.Models.Models
{
    public class SupplierModel : BaseModel
    {
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        [MinLength(1, ErrorMessage = "Company Name must be at least 1 characters")]
        [MaxLength(40, ErrorMessage = "Company Name can not be more than 40 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        [MinLength(1, ErrorMessage = "Contact Name must be at least 1 characters")]
        [MaxLength(30, ErrorMessage = "Contact Name can not be more than 30 characters")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        [MinLength(1, ErrorMessage = "Contact Name must be at least 1 characters")]
        [MaxLength(30, ErrorMessage = "Contact Name can not be more than 30 characters")]
        public string ContactTitle { get; set; }
        public BaseAddressModel Address { get; set; }
        public BaseCommunicationModel Communication { get; set; }
    }
}