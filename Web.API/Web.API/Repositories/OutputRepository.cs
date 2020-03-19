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
    public class OutputRepository : BaseRepository, IOutputRepository
    {
        public OutputRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Output>> ListAsync()
        {
            return await _context.Outputs.ToListAsync();
        }
        //**************************************************************************************************************
        public async Task<PagedList<OutputsItemViewModel>> GetAllPagingAsync(PagingParams pagingParams)
        {
            IQueryable<OutputsItemViewModel> _query = from phieuxuat in _context.Outputs
                                                      join khachhang in _context.Customers on phieuxuat.CustomerId equals khachhang.Makh
                                                      join vattu in _context.Stocks on phieuxuat.IdStock equals vattu.Mavt
                                                      select new OutputsItemViewModel
                                                      {
                                                          Mapx = phieuxuat.Mapx,
                                                          Tenpx = phieuxuat.Tenpx,
                                                          Ngayxuat = phieuxuat.Ngayxuat,
                                                          Tinhtrangxuat = phieuxuat.Tinhtrangxuat,
                                                          Thanhtien = phieuxuat.Thanhtien,
                                                          Soluongxuat = phieuxuat.Soluongxuat,
                                                          IdStock = vattu.Mavt,
                                                          CustomerId = khachhang.Makh,
                                                          Customername = khachhang.Tenkh,
                                                          Stockname = vattu.Tenvt,
                                                          Dongiaxuat = phieuxuat.Dongiaxuat,

                                                      };


            //************************************ Search ***************************************************************
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tenpx.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Mapx == _id);
                }
            }

            //***************************** SORT ************************************************************************* 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tenpx);
                else
                    _query = _query.OrderByDescending(o => o.Tenpx);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Mapx);
                else
                    _query = _query.OrderByDescending(o => o.Mapx);
            }


            return await PagedList<OutputsItemViewModel>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //************************************** LƯU DATA **********************************************************
        public async Task<Output> SaveAsync(Output _obj)
        {
            await _context.Outputs.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }

        //************************************ XÓA DATA VƠI ID ********************************************************
        public async Task<Output> DeleteAsync(int id)
        {
            var _obj = await _context.Outputs.Where(o => o.Mapx == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Outputs.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }


        //************************************ XÓA DATA VƠI TÊN ********************************************************
        public async Task<Output> DeleteWithName(string name)
        {
            var _obj = await _context.Outputs.Where(o => o.Tenpx == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Outputs.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
        //*************************************Cập nhật**********************************************
        public async Task<Output> UpdateAsync(int id, Output resource)
        {
            var _obj = await _context.Outputs.Where(o => o.Mapx == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tenpx = resource.Tenpx;
                _obj.Ngayxuat = resource.Ngayxuat;
                _obj.Soluongxuat = resource.Soluongxuat;
                _obj.Thanhtien = resource.Thanhtien;
                _obj.IdStock = resource.IdStock;
                _obj.CustomerId = resource.CustomerId;
                _obj.Tinhtrangxuat = resource.Tinhtrangxuat;
                _obj.Dongiaxuat = resource.Dongiaxuat;

                await _context.SaveChangesAsync();
            }
            return _obj;
        }
    }
}
