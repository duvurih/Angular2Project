namespace MultiProjectSample.Models.Models
{
    public class OrderDetailsModel : BaseModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public virtual ProductModel Product { get; set; }
    }
}