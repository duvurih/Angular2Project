using System.ComponentModel.DataAnnotations;

namespace MultiProjectSample.Models.Models
{
    public class BaseAddressModel : BaseModel
    {
        [Required(ErrorMessage = "Address is required")]
        [MinLength(1, ErrorMessage = "Address must be at least 1 character")]
        [MaxLength(60, ErrorMessage = "Address can not be more than 60 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MinLength(1, ErrorMessage = "City must be at least 1 character")]
        [MaxLength(15, ErrorMessage = "City can not be more than 15 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [MinLength(1, ErrorMessage = "Region must be at least 1 character")]
        [MaxLength(15, ErrorMessage = "Region can not be more than 15 characters")]
        public string Region { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Postal Code is required")]
        [MinLength(4, ErrorMessage = "Postal Code must be at least 4 characters")]
        [MaxLength(4, ErrorMessage = "Postal Code can not be more than 4 characters")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [MinLength(5, ErrorMessage = "Country must be at least 5 characters")]
        [MaxLength(15, ErrorMessage = "Country Code can not be more than 15 characters")]
        public string Country { get; set; }
    }
}