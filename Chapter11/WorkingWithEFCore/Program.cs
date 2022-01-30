using System;
using static System.Console;
using Packt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

namespace WorkingWithEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            //FilteredIncludes();
            //QueryingProducts();
            //QueryingWithLike();

            //if (AddProduct(6, "Bob's Burgers", 500M))
            //{
            //    WriteLine("Add product successful.");
            //}
            //if (IncreaseProductPrice("Bob", 20M))
            //{
            //    WriteLine("Update product price successful.");
            //}
            //int deleted = DeleteProducts("Bob");
            //WriteLine($"{deleted} product(s) were deleted.");
            //ListProducts();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Categories and how many products they have:");

                IQueryable<Category> cats; //= db.Categories.Include(c => c.Products);

                db.ChangeTracker.LazyLoadingEnabled = false;

                Write("Enable eager loading? (Y/N): ");
                bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
                WriteLine();

                if (eagerloading)
                {
                    cats = db.Categories.Include(c => c.Products);
                }
                else
                {
                    cats = db.Categories;
                }

                Write("Enable explicit loading? (Y/N): ");
                bool explicitloading = (ReadKey().Key == ConsoleKey.Y);
                WriteLine();

                foreach (Category c in cats)
                {
                    if (explicitloading)
                    {
                        Write($"Explicity load products for {c.CategoryName}? (Y/N): ");
                        ConsoleKeyInfo key = ReadKey();
                        WriteLine();
                        if (key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if (!products.IsLoaded)
                            {
                                products.Load();
                            }
                        }
                    }
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
                }
            }
        }

        static void FilteredIncludes()
        {
            using (var db = new Northwind())
            {
                Write("Enter a minimum for units in stock: ");
                string unitsInStock = ReadLine();
                int stock = int.Parse(unitsInStock);

                IQueryable<Category> cats = db.Categories.Include(c => c.Products.Where(p => p.Stock >= stock));
                WriteLine(cats.ToQueryString());
                foreach (Category c in cats)
                {
                    WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");

                    foreach (Product p in c.Products)
                    {
                        WriteLine($"   {p.ProductName} has {p.Stock} units in stock.");
                    }
                }
            }
        }

        static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                WriteLine("Products that cost more than a price, highest at top.");
                string input;
                decimal price;
                do
                {

                    Write("Enter a product price: ");
                    input = ReadLine();
                } while (!decimal.TryParse(input, out price));

                IQueryable<Product> products = db.Products
                    .TagWith("Products filtered by price and sorted.")
                    .Where(p => p.Cost > price)
                    .OrderByDescending(p => p.Cost);

                foreach (Product p in products)
                {
                    WriteLine($"{p.ProductID}: {p.ProductName} costs {p.Cost:$#,##0.00} and has {p.Stock} in stock.");
                }
            }
        }

        static void QueryingWithLike()
        {
            using (var db = new Northwind())
            {
                var loggerFactory = db.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new ConsoleLoggerProvider());

                Write("Enter a part of product name: ");
                string input = ReadLine();

                IQueryable<Product> prods = db.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
                foreach (Product p in prods)
                {
                    WriteLine($"{p.ProductName} has {p.Stock} units in stock. Discontinued? {p.Discontinued}.");
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product
                {
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };

                db.Add(newProduct);

                int affected = db.SaveChanges();
                return (affected > 0);
            }
        }

        static void ListProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine(
                    "{0,-3} {1,-35} {2,8} {3,5} {4}",
                    "ID", "Product Name", "Cost", "Stock", "Disc."
                );
                foreach (var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine(
                        "{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
                        item.ProductID, item.ProductName, item.Cost, item.Stock, item.Discontinued
                    );
                }
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(p => p.ProductName.StartsWith(name));

                updateProduct.Cost += amount;

                int affected = db.SaveChanges();
                return (affected > 0);
            }
        }

        static int DeleteProducts(string name)
        {
            using (var db = new Northwind())
            {
                using (IDbContextTransaction t = db.Database.BeginTransaction())
                {
                    WriteLine("Transaction isolation level: {0}", t.GetDbTransaction().IsolationLevel);

                    IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));

                    db.Products.RemoveRange(products);
                    int affected = db.SaveChanges();
                    
                    t.Commit();
                    
                    return affected;
                }
            }
        }
    }
}
