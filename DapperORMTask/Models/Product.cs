using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORMTask.Models
{
    internal class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public int Discontinued { get; set; }
        public int LastUserId { get; set; }
        public DateTime LastDateUpdated { get; set; }

        public Product(string productName, int supplierID, int categoryID, int quantityPerUnit, float unitPrice, int unitsInStock,int unitsOnOrder, int reorderLevel, int discontinued, int lastUserId, DateTime lastDateUpdated)
        {
            ProductName = productName;
            SupplierID = supplierID;
            CategoryID = categoryID;
            QuantityPerUnit = quantityPerUnit;
            UnitPrice = unitPrice;
            UnitsInStock = unitsInStock;
            UnitsOnOrder = unitsOnOrder;
            ReorderLevel = reorderLevel;
            Discontinued = discontinued;
            LastUserId = lastUserId;
            LastDateUpdated = lastDateUpdated;
        }

        public Product()
        {

        }

        public override string ToString()
        {
            return ProductID + " " + ProductName + " " + 
                SupplierID +" " + CategoryID + " " + QuantityPerUnit + " " + UnitPrice + " "+ 
                UnitsInStock + " " + ReorderLevel + " " + Discontinued + " " + 
                LastUserId + " " + LastDateUpdated.ToString();
        }
    }
}
