using System;
using System.Collections.Generic;

namespace MultiProjectSample.Models.Models
{
    public class OrderModel : BaseModel
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public BaseAddressModel AddressModel { get; set; }
        public string ShipName { get; set; }
        //public string ShipAddress { get; set; }
        //public string ShipCity { get; set; }
        //public string ShipRegion { get; set; }
        //public string ShipPostalCode { get; set; }
        //public string ShipCountry { get; set; }
        public virtual CustomerModel Customer { get; set; }

        public virtual ICollection<OrderDetailsModel> Order_Details { get; set; }
    }
}