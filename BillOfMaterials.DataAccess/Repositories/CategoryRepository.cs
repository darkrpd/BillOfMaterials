using BillOfMaterials.Core.Models;
using BillOfMaterials.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillOfMaterials.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BillOfMaterialsDbContext context)
             : base(context)
        { }

        private BillOfMaterialsDbContext BillOfMaterialsDbContext
        {
            get { return Context as BillOfMaterialsDbContext; }
        }

        // gets subcategories using main category's parentid column
        public async Task<IEnumerable<Category>> GetByParentIdAsync(int id)
        {
            return await BillOfMaterialsDbContext.Categories
             .Where(x => x.ParentId == id).ToListAsync();
        } 
    }
}
