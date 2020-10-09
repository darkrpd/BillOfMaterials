using BillOfMaterials.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BillOfMaterials.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetByParentIdAsync(int id);
    }
}
