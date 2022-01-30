using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMvc.Models;
using Microsoft.EntityFrameworkCore;
using Packt.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindMvc.Controllers
{
    public class CategoryController : Controller
    {
        private Northwind db;

        public CategoryController(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound("You must pass a category ID in the route, for example, /Category/21");
            }

            var model = await db.Categories.SingleOrDefaultAsync(c => c.CategoryID == id);
            if (model == null)
            {
                return NotFound($"Category with ID of {id} not found.");
            }

            return View(model);
        }
    }
}