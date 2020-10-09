using BillOfMaterials.Core;
using BillOfMaterials.Core.Models;
using BillOfMaterials.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillOfMaterials.Business
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> Create(Product newProduct)
        {
            await _unitOfWork.Products
                .AddAsync(newProduct);

            return newProduct;
        }

        public async Task Delete(Product Product)
        {
            _unitOfWork.Products.Remove(Product);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task Update(Product ProductToBeUpdated, Product Product)
        {
            ProductToBeUpdated.Name = Product.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}
