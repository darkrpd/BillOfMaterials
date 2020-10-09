using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillOfMaterials.Web.Models
{
    public class SubCategory
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentId { get; set; }
    }
}
