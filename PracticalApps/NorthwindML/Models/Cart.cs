using System.Collections.Generic;

namespace NorthwindML.Models
{
    public class Cart
    {
        public IEnumerable<CarItem> Items { get; set; }
    }
}