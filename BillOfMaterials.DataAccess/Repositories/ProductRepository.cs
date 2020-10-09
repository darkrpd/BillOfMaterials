using BillOfMaterials.Core.Models;
using BillOfMaterials.Core.Repositories;

namespace BillOfMaterials.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(BillOfMaterialsDbContext context)
            : base(context)
        { } 

        private BillOfMaterialsDbContext BillOfMaterialsDbContext
        {
            get { return Context as BillOfMaterialsDbContext; }
        }
    }
}
