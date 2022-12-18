using System;
using Dapper;
using DapperORMTask;
using DapperORMTask.Models;
using MySql.Data.MySqlClient;


// See https://aka.ms/new-console-template for more information


//FOR TESTING
//
//Return all categories

List<Category> categories = DBInterface.GetAllCategories();
Console.WriteLine("--ALL CATEGORIES--");
categories.ForEach(Console.WriteLine);


// Create a single product and order object
//

Product product = new Product("TestSecondName",1,1,2,(float)3.14,2,4,2,0,4,DateTime.Now);
Order order = new Order(1, 1, DateTime.Now, DateTime.Now, DateTime.Now, "Big boat", 12345.54m, "Biggest Boat", "Big Address", "Big City", "Big Region", "12345", "Big Country");


// The following code is commented so as not to spam database during testing

/* Then execute the INSERT INTO query via these methods.
//
DBInterface.CreateProduct(product);
DBInterface.CreateOrder(order);

// These functions require individual arguments instead of an entire object
//
DBInterface.CreateOrderDetail(5,2,(float)215.5,50,(float)20.3);
DBInterface.CreateCategory("TestName", "TestDescription", "TestPictureURL");
*/


// Return orders, ordered by date
//
List<Order> orders = DBInterface.GetOrdersByDate();
Console.WriteLine("--ALL ORDERS, SORTED BY DATE--");
orders.ForEach(Console.WriteLine);

// Return products, ordered by most sold
//
var products = DBInterface.GetProductsByMostSold();
Console.WriteLine("--ALL PRODUCTS, SORTED BY MOST SOLD--");
products.ForEach(Console.WriteLine);

// Return categories, ordered by most sold products in that category
//
var orderedCategories = DBInterface.GetCategoriesByMostSold();
Console.WriteLine("--ALL CATEGORIES, SORTED BY MOST SOLD PRODUCTS--");
orderedCategories.ForEach(Console.WriteLine);