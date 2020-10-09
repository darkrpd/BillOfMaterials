using BillOfMaterials.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillOfMaterials.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        IEnumerable<Product> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Create(Product newProduct);
        Task Update(Product ProductToBeUpdated, Product Product);
        Task Delete(Product Product);
    }
}
