using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORMTask.Models
{
    class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Order(int customerID, int employeeID, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, string shipVia, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
        {
            CustomerID = customerID;
            EmployeeID = employeeID;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            ShipVia = shipVia;
            Freight = freight;
            ShipName = shipName;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipRegion = shipRegion;
            ShipPostalCode = shipPostalCode;
            ShipCountry = shipCountry;
        }

        public Order()
        {

        }

        //mora da ima poubav nacin
        public override string? ToString()
        {
            return OrderID + " " + CustomerID + " " + EmployeeID + " " +
                OrderDate + " " + RequiredDate + " " + ShippedDate + " " + 
                ShipVia + " " + Freight + " " + ShipName + " " + ShipAddress + " " +
                ShipCity + " " + ShipRegion + " " + ShipPostalCode + " " + ShipCountry;
        }
    }
}
