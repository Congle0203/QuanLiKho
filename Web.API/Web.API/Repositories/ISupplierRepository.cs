﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Repository;

namespace Web.API.Repositories
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> ListAsync();

        Task<PagedList<Supplier>> GetAllPagingAsync(PagingParams pagingParams);

        Task<Supplier> SaveAsync(Supplier supplier);


        Task<Supplier> DeleteAsync(int id);


        Task<Supplier> DeleteWithName(string name);

        Task<Supplier> UpdateAsync(int id, Supplier resource);
    }
}
