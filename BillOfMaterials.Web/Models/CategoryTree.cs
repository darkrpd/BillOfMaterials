﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillOfMaterials.Web.Models
{
    public class CategoryTree
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<CategoryTree> categories { get; set; }
    }
}
