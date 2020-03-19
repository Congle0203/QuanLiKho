using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Resources;

namespace Web.API.Repository
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> ListAsync();

        Task<PagedList<StocksItemViewModel>> GetAllPagingAsync(PagingParams pagingParams);

        Task<Stock> SaveAsync(Stock stock);


        Task<Stock> DeleteAsync(int id);


        Task<Stock> DeleteWithName(string name);

        Task<Stock> UpdateAsync(int id, Stock resource);
    }
}
