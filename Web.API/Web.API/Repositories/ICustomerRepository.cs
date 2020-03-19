using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;

namespace Web.API.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> ListAsync();

        Task<PagedList<Customer>> GetAllPagingAsync(PagingParams pagingParams);

        Task<Customer> SaveAsync(Customer customer);

        Task<Customer> DeleteAsync(int id);

        Task<Customer> DeleteWithName(string name);

        Task<Customer> UpdateAsync(int id, Customer resource);
    }
}
