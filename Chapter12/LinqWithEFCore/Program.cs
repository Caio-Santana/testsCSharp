﻿using static System.Console;
using System.Linq;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace LinqWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //FilterAndSort();
            //JoinCategoriesAndProducts();
            //GroupJoinCategoriesAndProducts();
            //AggregateProducts();
            //CustomExtensionMethods();
            //OutputProductsAsXml();
            //ProcessSettings();
            Exercise02();
        }

        static void FilterAndSort()
        {
            using (var db = new Northwind())
            {
                var query = db.Products
                   .ProcessSequence()
                   .Where(product => product.UnitPrice < 10M)
                   .OrderByDescending(product => product.UnitPrice)
                   .Select(product => new
                   {
                       product.ProductID,
                       product.ProductName,
                       product.UnitPrice
                   });

                WriteLine("Products that cost less than $10:");
                foreach (var item in query)
                {
                    WriteLine("{0}: {1} costs {2:$#,##0.00}", item.ProductID, item.ProductName, item.UnitPrice);
                }
                WriteLine();
            }
        }

        static void JoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryJoin = db.Categories
                    .Join(
                        inner: db.Products,
                        outerKeySelector: category => category.CategoryID,
                        innerKeySelector: product => product.CategoryID,
                        resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductID })
                    .OrderBy(cp => cp.CategoryName);

                foreach (var item in queryJoin)
                {
                    WriteLine(
                        "{0}: {1} is in {2}.",
                        item.ProductID,
                        item.ProductName,
                        item.CategoryName
                    );
                }
            }
        }

        static void GroupJoinCategoriesAndProducts()
        {
            using (var db = new Northwind())
            {
                var queryGroup = db.Categories.AsEnumerable()
                    .GroupJoin(
                        inner: db.Products,
                        outerKeySelector: category => category.CategoryID,
                        innerKeySelector: product => product.CategoryID,
                        resultSelector: (c, matchingProducts) => new
                        {
                            c.CategoryName,
                            Products = matchingProducts.OrderBy(p => p.ProductName)
                        });

                foreach (var item in queryGroup)
                {
                    WriteLine(
                        "{0} has {1} products.",
                        item.CategoryName,
                        item.Products.Count()
                    );
                    foreach (var product in item.Products)
                    {
                        WriteLine($"    {product.ProductName}");
                    }
                }
            }
        }

        static void AggregateProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("{0,-25} {1,10}", "Product count:", db.Products.Count());
                WriteLine("{0,-25} {1,10:$#,##0.00}", "Highest product price:", db.Products.Max(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:N0}", "Sum of units in stock:", db.Products.Sum(p => p.UnitsInStock));
                WriteLine("{0,-25} {1,10:N0}", "Sum of units on order:", db.Products.Sum(p => p.UnitsOnOrder));
                WriteLine("{0,-25} {1,10:$#,##0.00}", "Average unit price:", db.Products.Average(p => p.UnitPrice));
                WriteLine("{0,-25} {1,10:$#,##0.00}", "Value of units in stock:", db.Products.AsEnumerable().Sum(p => p.UnitPrice * p.UnitsInStock));
            }
        }

        static void CustomExtensionMethods()
        {
            using (var db = new Northwind())
            {
                WriteLine("Mean units in stock: {0:N0}", db.Products.Average(p => p.UnitsInStock));
                WriteLine("Mean unit price: {0:$#,##0.00}", db.Products.Average(p => p.UnitPrice));
                WriteLine("Median units in stock: {0:N0}", db.Products.Median(p => p.UnitsInStock));
                WriteLine("Median unit price: {0:$#,##0.00}", db.Products.Median(p => p.UnitPrice));
                WriteLine("Mode units in stock: {0:N0}", db.Products.Mode(p => p.UnitsInStock));
                WriteLine("Mode unit price: {0:$#,##0.00}", db.Products.Mode(p => p.UnitPrice));
            }
        }

        static void OutputProductsAsXml()
        {
            using (var db = new Northwind())
            {
                var productsForXml = db.Products.ToArray();
                var xml = new XElement("products",
                    from p in productsForXml
                    select new XElement("product",
                        new XAttribute("id", p.ProductID),
                        new XAttribute("price", p.UnitPrice),
                        new XElement("name", p.ProductName)
                    )
                );
                WriteLine(xml.ToString());
            }
        }

        static void ProcessSettings()
        {
            XDocument doc = XDocument.Load("settings.xml");
            var appSettings = doc.Descendants("appSettings")
                .Descendants("add")
                .Select(node => new
                {
                    Key = node.Attribute("key").Value,
                    Value = node.Attribute("value").Value,
                }).ToArray();

            foreach (var item in appSettings)
            {
                WriteLine($"{item.Key}: {item.Value}");
            }

        }

        static void Exercise02()
        {
            using (var db = new Northwind())
            {
                Write("Enter the name of a city: ");
                string city = ReadLine();

                var query = db.Customers
                    .Where(c => c.City == city)
                    .Select(c => new { c.CompanyName });
                
                WriteLine($"There are {query.Count()} customers in {city}:");
                foreach (var item in query)
                {
                    WriteLine(item.CompanyName);
                }
            }
        }
    }
}