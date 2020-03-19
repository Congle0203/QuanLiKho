using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Repository;

using static Web.API.Repository.BaseResposiorty;

namespace Web.API.Repositories
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository(AppDbContext context) : base(context)
        {
        }
        //*************************************************************************************************************
        public async Task<IEnumerable<Supplier>> ListAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }
        //**************************************************************************************************************
        public async Task<PagedList<Supplier>> GetAllPagingAsync(PagingParams pagingParams)
        {
            IQueryable<Supplier> _query = from u in _context.Suppliers
                                          orderby u.Tenncc
                                           select new Supplier { Mancc = u.Mancc, Tenncc = u.Tenncc, Diachi = u.Diachi, Sdt = u.Sdt};

            //************************************ Search ***************************************************************
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tenncc.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Mancc == _id);
                }
            }

            //***************************** SORT ************************************************************************* 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tenncc);
                else
                    _query = _query.OrderByDescending(o => o.Tenncc);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Mancc);
                else
                    _query = _query.OrderByDescending(o => o.Mancc);
            }


            return await PagedList<Supplier>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //************************************** LƯU DATA **********************************************************
        public async Task<Supplier> SaveAsync(Supplier _obj)
        {
            await _context.Suppliers.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }

        //************************************ XÓA DATA VƠI ID ********************************************************
        public async Task<Supplier> DeleteAsync(int id)
        {
            var _obj = await _context.Suppliers.Where(o => o.Mancc == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Suppliers.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }


        //************************************ XÓA DATA VƠI TÊN ********************************************************
        public async Task<Supplier> DeleteWithName(string name)
        {
            var _obj = await _context.Suppliers.Where(o => o.Tenncc == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Suppliers.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
        //************************************************************************************************************
        public async Task<Supplier> UpdateAsync(int id, Supplier resource)
        {
            var _obj = await _context.Suppliers.Where(o => o.Mancc == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tenncc = resource.Tenncc;
                _obj.Diachi = resource.Diachi;
                _obj.Sdt = resource.Sdt;


                await _context.SaveChangesAsync();
            }
            return _obj;
        }
    }
}
