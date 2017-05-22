using System;
using System.ComponentModel.DataAnnotations;

namespace MultiProjectSample.Models.Models
{
    public class ProductModel : BaseModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [MinLength(3, ErrorMessage = "Product Name must be at least 3 characters")]
        [MaxLength(15, ErrorMessage = "Product Name can not be more than 40 characters")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Supplier is required")]
        public Nullable<int> SupplierID { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public Nullable<int> CategoryID { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string QuantityPerUnit { get; set; }

        [Required(ErrorMessage = "Unit Price is required")]
        public Nullable<decimal> UnitPrice { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        public Nullable<short> UnitsInStock { get; set; }

        [Required(ErrorMessage = "Order quantity is required")]
        public Nullable<short> UnitsOnOrder { get; set; }

        [Required(ErrorMessage = "Reorder level is required")]
        public Nullable<short> ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}