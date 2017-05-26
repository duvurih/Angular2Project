using System.ComponentModel.DataAnnotations;

namespace MultiProjectSample.Models.Models
{
    public class BaseCommunicationModel : BaseModel
    {
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone is required")]
        [MinLength(8, ErrorMessage = "Phone must be at least 8 characters")]
        [MaxLength(12, ErrorMessage = "Phone can not be more than 15 characters")]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MinLength(8, ErrorMessage = "Fax must be at least 8 character")]
        [MaxLength(12, ErrorMessage = "Fax can not be more than 12 characters")]
        public string Fax { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(12, ErrorMessage = "Home Page Url can not be more than 100 characters")]
        public string HomePage { get; set; }
    }
}