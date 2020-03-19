using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;

namespace Web.API.Repository
{
    public interface IUnitRepository
    { 
        Task<IEnumerable<Unit>> ListAsync();

        Task<PagedList<Unit>> GetAllPagingAsync(PagingParams pagingParams);

        Task<Unit> SaveAsync(Unit unit);

        Task<Unit> DeleteAsync(int id);

        Task<Unit> DeleteWithName(string name);

        Task<Unit> UpdateAsync(int id, Unit resource);
    }
}
