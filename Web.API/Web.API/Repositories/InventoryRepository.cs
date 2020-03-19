using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using static Web.API.Repository.BaseResposiorty;

namespace Web.API.Repository
{
    public class InventoryRepository : BaseRepository, IInventoryRepository
    {
        public InventoryRepository(AppDbContext context) : base(context)
        {
        }
        //*************************************************************************************************************
        public async Task<IEnumerable<Inventory>> ListAsync()
        {
            return await _context.Inventories.ToListAsync();
        }
        //**************************************************************************************************************
        public async Task<PagedList<Inventory>> GetAllPagingAsync(PagingParams pagingParams)
        {
            IQueryable<Inventory> _query = from u in _context.Inventories
                                           orderby u.Tenkho
                                           select new Inventory { Makho = u.Makho, Tenkho = u.Tenkho };

            //************************************ Search ***************************************************************
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tenkho.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Makho == _id);
                }
            }

            //***************************** SORT ************************************************************************* 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tenkho);
                else
                    _query = _query.OrderByDescending(o => o.Tenkho);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Makho);
                else
                    _query = _query.OrderByDescending(o => o.Makho);
            }


            return await PagedList<Inventory>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //************************************** LƯU DATA **********************************************************
        public async Task<Inventory> SaveAsync(Inventory _obj)
        {
            await _context.Inventories.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }

        //************************************ XÓA DATA VƠI ID ********************************************************
        public async Task<Inventory> DeleteAsync(int id)
        {
            var _obj = await _context.Inventories.Where(o => o.Makho == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Inventories.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }


        //************************************ XÓA DATA VƠI TÊN ********************************************************
        public async Task<Inventory> DeleteWithName(string name)
        {
            var _obj = await _context.Inventories.Where(o => o.Tenkho == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Inventories.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
        //************************************************************************************************************
        public async Task<Inventory> UpdateAsync(int id, Inventory resource)
        {
            var _obj = await _context.Inventories.Where(o => o.Makho == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tenkho = resource.Tenkho;


                await _context.SaveChangesAsync();
            }
            return _obj;
        }
    }

}
