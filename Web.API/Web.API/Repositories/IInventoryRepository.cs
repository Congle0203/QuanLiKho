using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;

namespace Web.API.Repository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> ListAsync();
        Task<PagedList<Inventory>> GetAllPagingAsync(PagingParams pagingParams);
        Task<Inventory> SaveAsync(Inventory inventory);

        Task<Inventory> DeleteAsync(int id);

        Task<Inventory> DeleteWithName(string name);

        Task<Inventory> UpdateAsync(int id, Inventory resource);

    }
}
