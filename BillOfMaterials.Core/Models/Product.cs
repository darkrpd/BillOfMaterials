using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterials.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
