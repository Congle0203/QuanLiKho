using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Repository;
using Web.API.Resources;
using static Web.API.Repository.BaseResposiorty;

namespace Web.API.Repositories
{
    public class InputRepository : BaseRepository, IInputRepository
    {
        
        public InputRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Input>> ListAsync()
        {
            return await _context.Inputs.ToListAsync();
        }

        public async Task<PagedList<InputsItemViewModel>> GetAllPagingAsync(PagingParams pagingParams)
        {
            //IQueryable<Input> _query = from u in _context.Inputs
            //                           orderby u.Tenpn
            //                           select new Input
            //                           {
            //                               Mapn = u.Mapn,
            //                               Tenpn = u.Tenpn,
            //                               Ngaynhap = u.Ngaynhap,
            //                               Soluongnhap = u.Soluongnhap,
            //                               Tinhtrang = u.Tinhtrang,
            //                               Dongianhap = u.Dongianhap,
            //                               //SupplierId = u.SupplierId,
            //                               StockId = u.StockId,

            //                           
            IQueryable<InputsItemViewModel> _query = from phieunhap in _context.Inputs
                                                     join vattu in _context.Stocks on phieunhap.StockId equals vattu.Mavt
                                                     select new InputsItemViewModel
                                                     {
                                                         Dongianhap = phieunhap.Dongianhap,
                                                         StockId = vattu.Mavt,
                                                         Mapn = phieunhap.Mapn,
                                                         Ngaynhap = phieunhap.Ngaynhap,
                                                         Soluongnhap = phieunhap.Soluongnhap,
                                                         Stockname = vattu.Tenvt,
                                                         Tenpn = phieunhap.Tenpn,
                                                         Tinhtrang = phieunhap.Tinhtrang,

                                                     };

            //********************************************************************************************************************
            // Search
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tenpn.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Mapn == _id);
                }
            }
            //***********************************************************************************************************************
            //Sort 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tenpn);
                else
                    _query = _query.OrderByDescending(o => o.Tenpn);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Mapn);
                else
                    _query = _query.OrderByDescending(o => o.Mapn);
            }

            return await PagedList<InputsItemViewModel>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //*****************************************************************************************************************************
        public async Task<Input> SaveAsync(Input _obj)
        {
            await _context.Inputs.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }

        //*****************************************************************************************************************************
        public async Task<Input> DeleteAsync(int id)
        {
            var _obj = await _context.Inputs.Where(o => o.Mapn == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Inputs.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }


        //********************************************************************************************************************************
        public async Task<Input> DeleteWithName(string name)
        {
            var _obj = await _context.Inputs.Where(o => o.Tenpn == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Inputs.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
        //*******************************************************************************************************************************
        public async Task<Input> UpdateAsync(int id, Input resource)
        {
            var _obj = await _context.Inputs.Where(o => o.Mapn == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tenpn = resource.Tenpn;
                _obj.Ngaynhap = resource.Ngaynhap;
                _obj.Soluongnhap = resource.Soluongnhap;
                _obj.Tinhtrang = resource.Tinhtrang;
                _obj.StockId = resource.StockId;
                _obj.Dongianhap = resource.Dongianhap;

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
    }
}

