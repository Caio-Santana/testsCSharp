using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Packt.Shared;

namespace PacktFeatures.Pages
{
    public class CustomersPageModel : PageModel
    {
        private Northwind db;

        public IEnumerable<Customer> Customers { get; set; }

        public CustomersPageModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            Customers = db.Customers.ToArray();
        }
    }
}
