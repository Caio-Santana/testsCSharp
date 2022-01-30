using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Packt.Shared;
using NorthwindCms2.Models;
using Microsoft.EntityFrameworkCore;

namespace NorthwindCms2.Controllers
{
    public class ImportController : Controller
    {
        private readonly IApi api;
        private readonly Northwind db;

        public ImportController(IApi api, Northwind injectedContext)
        {
            this.api = api;
            db = injectedContext;
        }

        [Route("/import")]
        public async Task<IActionResult> Import()
        {
            int importCount = 0;
            int existCount = 0;

            var site = await api.Sites.GetDefaultAsync();

            var catalog = await api.Pages.GetBySlugAsync<CatalogPage>("catalog");

            foreach (Category c in db.Categories.Include(c => c.Products))
            {
                CategoryPage cp = await api.Pages.GetBySlugAsync<CategoryPage>($"catalog/{c.CategoryName.ToLower().Replace(' ', '-')}");

                if (cp == null)
                {
                    importCount++;

                    cp = await CategoryPage.CreateAsync(api);

                    cp.Id = Guid.NewGuid();
                    cp.SiteId = site.Id;
                    cp.ParentId = catalog.Id;
                    cp.CategoryDetail.CategoryID = c.CategoryID;
                    cp.CategoryDetail.CategoryName = c.CategoryName;
                    cp.CategoryDetail.Description = c.Description;

                    Guid categoriesFolderID = (await api.Media.GetAllFoldersAsync())
                        .First(folder => folder.Name == "Categories").Id;

                    var image = (await api.Media.GetAllByFolderIdAsync(categoriesFolderID))
                        .First(media => media.Type == MediaType.Image && media.Filename == $"category{c.CategoryID}.jpeg");

                    cp.CategoryDetail.CategoryImage = image;

                    if (cp.Products.Count == 0)
                    {
                        cp.Products = c.Products
                            .Select(p => new ProductRegion
                            {
                                ProductID = p.ProductID,
                                ProductName = p.ProductName,
                                UnitPrice = p.UnitPrice.HasValue ? p.UnitPrice.Value.ToString("c") : "n/a",
                                UnitsInStock = p.UnitsInStock ?? 0
                            }).ToList();
                    }

                    cp.Title = c.CategoryName;
                    cp.MetaDescription = c.Description;
                    cp.NavigationTitle = c.CategoryName;
                    cp.Published = DateTime.Now;

                    await api.Pages.SaveAsync(cp);
                }
                else
                {
                    existCount++;
                }
            }
            TempData["import_message"] = $"{existCount} categories already existed. {importCount} new categories imported.";
            
            return Redirect("~/");
        }
    }
}