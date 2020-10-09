using BillOfMaterials.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillOfMaterials.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(int id);
        Task<IEnumerable<Category>> GetByParentId(int id);
        Task<Category> Create(Category newCategory);
        Task Update(Category CategoryToBeUpdated, Category Category);
        Task Delete(Category Category);
    }
}
