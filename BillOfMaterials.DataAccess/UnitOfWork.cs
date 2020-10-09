using BillOfMaterials.Core;
using BillOfMaterials.Core.Repositories;
using BillOfMaterials.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillOfMaterials.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BillOfMaterialsDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(BillOfMaterialsDbContext context)
        {
            this._context = context;
        }

        public ICategoryRepository Categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
