using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using static Web.API.Repository.BaseResposiorty;

namespace Web.API.Repository
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<PagedList<Customer>> GetAllPagingAsync(PagingParams pagingParams)
        {
            IQueryable<Customer> _query = from u in _context.Customers
                                          orderby u.Tenkh
                                          select new Customer { Makh = u.Makh, Tenkh = u.Tenkh, Diachi = u.Diachi, Sdt = u.Sdt  };
            //********************************************************************************************************************
            // Search
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tenkh.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Makh == _id);
                }
            }
            //***********************************************************************************************************************
            //Sort 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tenkh);
                else
                    _query = _query.OrderByDescending(o => o.Tenkh);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Makh);
                else
                    _query = _query.OrderByDescending(o => o.Makh);
            }

            return await PagedList<Customer>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //*****************************************************************************************************************************
        public async Task<Customer> SaveAsync(Customer _obj)
        {
            await _context.Customers.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }

        //*****************************************************************************************************************************
        public async Task<Customer> DeleteAsync(int id)
        {
            var _obj = await _context.Customers.Where(o => o.Makh == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Customers.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }


        //********************************************************************************************************************************
        public async Task<Customer> DeleteWithName(string name)
        {
            var _obj = await _context.Customers.Where(o => o.Tenkh == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Customers.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
        //*******************************************************************************************************************************
        public async Task<Customer> UpdateAsync(int id, Customer resource)
        {
            var _obj = await _context.Customers.Where(o => o.Makh == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tenkh = resource.Tenkh;
                _obj.Sdt = resource.Sdt;
                _obj.Diachi = resource.Diachi;
                _obj.Sdt = resource.Sdt;
                await _context.SaveChangesAsync();
            }
            return _obj;
        }
    }
}
