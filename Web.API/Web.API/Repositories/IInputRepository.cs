using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Resources;

namespace Web.API.Repository
{
    public interface IInputRepository
    {
        Task<IEnumerable<Input>> ListAsync();
        //Task<PagedList<Input>> GetAllPagingAsync(PagingParams pagingParams);
        Task<PagedList<InputsItemViewModel>> GetAllPagingAsync(PagingParams pagingParams);
        Task<Input> SaveAsync(Input input);

        Task<Input> DeleteAsync(int id);

        Task<Input> DeleteWithName(string name);

        Task<Input> UpdateAsync(int id, Input resource);
    }
}
