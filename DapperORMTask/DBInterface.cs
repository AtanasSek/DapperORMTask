using Dapper;
using DapperORMTask.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORMTask
{
    static class DBInterface
    {
        private static String connectionString = "Server=localhost;Database=dapperschema;User=dapperuser;Password=dapperpass";
        //SET FOREIGN_KEY_CHECKS = 0; ignoriraj foreign key check pri table update

        //GET: Return all categories
        public static List<Category> GetAllCategories()
        {
            
            List<Category> categories;       

            string getCategoriesQuery = "Select * from categories";

            using (var connection = new MySqlConnection(connectionString))
            {
                
                 categories = connection.Query<Category>(getCategoriesQuery).ToList();
                
            }

            return categories;
        }

        //POST: Add a new category
        public static void CreateCategory(String categoryName, String description, string picture)
        {

            string insertCategoryQuery = "INSERT INTO categories (CategoryName, Description, Picture) " +
                "VALUES (@CategoryName, @Description, @Picture)";

            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Execute(insertCategoryQuery, new {CategoryName = categoryName, Description = description, Picture = picture});
            
            }
        }

        //POST: Add a new product
        public static void CreateProduct(Product product)
        {

            //Sigurno ima poubav i popregleden nacin?
            string insertProductQuery = "INSERT INTO products(ProductName, SupplierID, CategoryID, " +
                "QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, " +
                "ReorderLevel, Discontinued, LastUserId, LastDateUpdated)" +
                "VALUES (@ProductName, @SupplierID, @CategoryID, " +
                "@QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, " +
                "@ReorderLevel, @Discontinued, @LastUserId, @LastDateUpdated)";

            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Execute(insertProductQuery, product);

            }
        }

        //POST: Add a new order
        public static void CreateOrder(Order order)
        {
            string insertOrderQuery = "INSERT INTO orders(CustomerID, EmployeeID, OrderDate, " +
                "RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity," +
                "ShipRegion, ShipPostalCode, ShipCountry )" +
                "VALUES (@CustomerID, @EmployeeID, @OrderDate, " +
                "@RequiredDate, @ShippedDate, @ShipVia, @Freight, @ShipName, @ShipAddress, @ShipCity," +
                "@ShipRegion, @ShipPostalCode, @ShipCountry)";


            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Execute(insertOrderQuery, order);

            }
        }

        //POST: Add a new order_detail
        public static void CreateOrderDetail(int orderId,int productId, float unitPrice, int quantity, float discount)
        {
            string insertCategoryQuery = "INSERT INTO order_details (OrderID, ProductID, UnitPrice, Quantity, Discount) " +
                "VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount) ";

            using (var connection = new MySqlConnection(connectionString))
            {

                connection.Execute(insertCategoryQuery, new { OrderID = orderId, ProductID = productId, UnitPrice = unitPrice, Quantity = quantity, Discount = discount });
                
            }
        }

        //GET: Return orders sorted by date
        public static List<Order> GetOrdersByDate()
        {
            string getOrderQuery = "SELECT * FROM orders ORDER BY OrderDate, RequiredDate, ShippedDate";
            List<Order> orders;
            using (var connection = new MySqlConnection(connectionString))
            {

                orders = connection.Query<Order>(getOrderQuery).ToList();

            }
            return orders;
        }

        //GET: Return products sorted by most sold
        public static List<dynamic> GetProductsByMostSold()
        {
            string getProductQuery = "SELECT ProductID, ProductName, CategoryID, SUM(Quantity) " +
                "FROM (SELECT p.ProductID, p.ProductName, p.CategoryID, od.Quantity " +
                "FROM products AS p " +
                "JOIN order_details AS od ON p.ProductID = od.ProductID) AS T GROUP BY ProductID " +
                "ORDER BY SUM(Quantity) DESC ";
           

            using (var connection = new MySqlConnection(connectionString))
            {
                var products = connection.Query(getProductQuery).ToList();

                return products;
            }

        }

        //GET: Return categories by most sold products in said categories.
        public static List<dynamic> GetCategoriesByMostSold()
        {
            string getProductQuery = "SELECT ProductID, ProductName, CategoryID, SUM(Quantity) " +
                "FROM (SELECT p.ProductID, p.ProductName, p.CategoryID, od.Quantity " +
                "FROM products AS p " +
                "JOIN order_details AS od ON p.ProductID = od.ProductID) AS T GROUP BY CategoryID " +
                "ORDER BY SUM(Quantity) DESC ";


            using (var connection = new MySqlConnection(connectionString))
            {
                var categories = connection.Query(getProductQuery).ToList();

                return categories;
            }
        }
    }
}
