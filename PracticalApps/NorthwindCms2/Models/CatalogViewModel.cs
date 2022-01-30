using System.Collections.Generic;

namespace NorthwindCms2.Models
{
    public class CatalogViewModel
    {
        public CatalogPage CatalogPage { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }
    }
}