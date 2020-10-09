using System;
using System.Collections.Generic;
using System.Text;

namespace BillOfMaterials.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; } 
    }
}
