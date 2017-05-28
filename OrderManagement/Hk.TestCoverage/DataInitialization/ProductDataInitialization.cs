using Hk.Application1.Core.Models;
using System.Collections.Generic;

namespace Hk.TestCoverage.DataInitialization
{
    public static class ProductDataInitialization
    {
        public static IEnumerable<Product> ProductTestData()
        {
            List<Product> productData = new List<Product>();
            for (int i = 1; i <= 10; i++)
            {
                productData.Add(new Product
                {
                    ProductID = i,
                    ProductName = "Product Name " + i,
                    SupplierID = 1,
                    CategoryID = 1,
                    QuantityPerUnit = "Boxes - " + i,
                    UnitPrice = 2 * i,
                    UnitsInStock = (short)(3 * i),
                    UnitsOnOrder = (short)(4 * i),
                    ReorderLevel = (short)(5 * i),
                    Discontinued = true
                });
            }
            return productData;
        }
    }
}
