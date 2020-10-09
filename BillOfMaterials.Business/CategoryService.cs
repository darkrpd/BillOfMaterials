using BillOfMaterials.Core;
using BillOfMaterials.Core.Models;
using BillOfMaterials.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillOfMaterials.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> Create(Category newCategory)
        {
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;
        }

        public async Task Delete(Category Category)
        {
            _unitOfWork.Categories.Remove(Category);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories
                .GetAllAsync(); 
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories
                .GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetByParentId(int id)
        {
            return await _unitOfWork.Categories
               .GetByParentIdAsync(id);
        }

        public async Task Update(Category CategoryToBeUpdated, Category Category)
        {
            CategoryToBeUpdated.Name = Category.Name;

            await _unitOfWork.CommitAsync();
        }

    }
}
