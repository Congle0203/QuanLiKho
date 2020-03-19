using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Resources;
using static Web.API.Repository.BaseResposiorty;

namespace Web.API.Repository
{
    public class StockRepository : BaseRepository, IStockRepository
    {
        public StockRepository(AppDbContext context) : base(context)
        {
        }
        //********************************************************************************************************
        public async Task<IEnumerable<Stock>> ListAsync()
        {
            return await _context.Stocks.ToListAsync();
        }
        //********************************************************************************************************************
        public async Task<PagedList<StocksItemViewModel>> GetAllPagingAsync(PagingParams pagingParams)
        {
            IQueryable<StocksItemViewModel> _query = from vattu in _context.Stocks
                                                     join donvi in _context.Units on vattu.UnitId equals donvi.Madv
                                                     join kho in _context.Inventories on vattu.InventoryId equals kho.Makho
                                                     join ncc in _context.Suppliers on vattu.SupplierId equals ncc.Mancc
                                                     select new StocksItemViewModel {
                                                         Mavt = vattu.Mavt,
                                                         Tenvt = vattu.Tenvt,
                                                         InventoryId = kho.Makho,
                                                         Inventoryname = kho.Tenkho,
                                                         UnitId = donvi.Madv,
                                                         Unitname = donvi.Tendv,
                                                         Soluong = vattu.Soluong,
                                                         Noisx = vattu.Noisx,
                                                         SupplierId = ncc.Mancc,
                                                         Suppliername = ncc.Tenncc,
                                                        
                                                     };
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tenvt.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Mavt == _id);
                }
            }
          
            //Sort 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tenvt);
                else
                    _query = _query.OrderByDescending(o => o.Tenvt);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Mavt);
                else
                    _query = _query.OrderByDescending(o => o.Mavt);
            }

            return await PagedList<StocksItemViewModel>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //***************************************************************************************************************
        public async Task<Stock> SaveAsync(Stock _obj)
        {
            await _context.Stocks.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }
        //**************************************************************************************************************
        public async Task<Stock> DeleteAsync(int id)
        {
            var _obj = await _context.Stocks.Where(o => o.Mavt == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Stocks.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }

        //****************************************************************************************************
        public async Task<Stock> DeleteWithName(string name)
        {
            var _obj = await _context.Stocks.Where(o => o.Tenvt == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Stocks.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }

        //*********************************************************************************************************
        public async Task<Stock> UpdateAsync(int id, Stock resource)
        {
            var _obj = await _context.Stocks.Where(o => o.Mavt == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tenvt = resource.Tenvt;
                _obj.Noisx = resource.Noisx;
                _obj.Soluong = resource.Soluong;
                _obj.InventoryId = resource.InventoryId;
                _obj.UnitId = resource.UnitId;
                _obj.SupplierId = resource.SupplierId;

                await _context.SaveChangesAsync();
            }
            return _obj;
        }

        
    }
}