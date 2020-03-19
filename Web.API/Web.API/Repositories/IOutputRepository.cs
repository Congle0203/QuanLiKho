using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Repository;
using Web.API.Resources;

namespace Web.API.Repositories
{
    public interface IOutputRepository
    {

        Task<IEnumerable<Output>> ListAsync();

        Task<PagedList<OutputsItemViewModel>> GetAllPagingAsync(PagingParams pagingParams);

        Task<Output> SaveAsync(Output output);

        Task<Output> DeleteAsync(int id);

        Task<Output> DeleteWithName(string name);

        Task<Output> UpdateAsync(int id, Output resource);
    }
}
