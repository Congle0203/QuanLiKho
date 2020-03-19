//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Web.API.Helper;
//using Web.API.Repository;
//using static Web.API.Repository.BaseResposiorty;

//namespace Web.API.Repositories
//{
//    public class OutputInfoRepository:  BaseRepository, IOutputInfoRepository
//    {

//        public OutputInfoRepository(AppDbContext context) : base(context)
//        {
//        }
//        //*************************************************************************************************************
//        public async Task<IEnumerable<OutputInfo>> ListAsync()
//        {
//            return await _context.OutputsInfo.ToListAsync();
//        }
//        //**************************************************************************************************************
//        public async Task<PagedList<OutputInfo>> GetAllPagingAsync(PagingParams pagingParams)
//        {
//            IQueryable<OutputInfo> _query = from u in _context.OutputsInfo
//                                            orderby u.Mapxinfo
//                                           select new OutputInfo { Mapxinfo = u.Mapxinfo, CustomerId = u.CustomerId, OutputId = u.OutputId, Soluong = u.Soluong, StockId = u.StockId, Trangthai = u.Trangthai};

//            //************************************ Search ***************************************************************
//            //if (pagingParams.SearchValue == "name")
//            //{
//            //    if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
//            //    {
//            //        _query = _query.Where(o => o.Tenpn.Contains(pagingParams.SearchKey));
//            //    }
//            //}

//            if (pagingParams.SearchValue == "id")
//            {
//                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
//                {
//                    int _id = Convert.ToInt32(pagingParams.SearchKey);

//                    _query = _query.Where(o => o.Mapxinfo == _id);
//                }
//            }

//            //***************************** SORT ************************************************************************* 
//            //if (pagingParams.SortKey == "name")
//            //{
//            //    if (pagingParams.SortValue == "ascend")

//            //        _query = _query.OrderBy(o => o.Tenpn);
//            //    else
//            //        _query = _query.OrderByDescending(o => o.Tenpn);
//            //}

//            if (pagingParams.SortKey == "id")
//            {
//                if (pagingParams.SortValue == "ascend")

//                    _query = _query.OrderBy(o => o.Mapxinfo);
//                else
//                    _query = _query.OrderByDescending(o => o.Mapxinfo);
//            }


//            return await PagedList<OutputInfo>
//                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
//        }
//        //************************************** LƯU DATA **********************************************************
//        public async Task<OutputInfo> SaveAsync(OutputInfo _obj)
//        {
//            await _context.OutputsInfo.AddAsync(_obj);
//            await _context.SaveChangesAsync();

//            return _obj;

//        }

//        //************************************ XÓA DATA VƠI ID ********************************************************
//        public async Task<OutputInfo> DeleteAsync(int id)
//        {
//            var _obj = await _context.OutputsInfo.Where(o => o.Mapxinfo == id).FirstOrDefaultAsync();
//            if (_obj != null)
//            {
//                _context.OutputsInfo.Remove(_obj);

//                await _context.SaveChangesAsync();
//            }
//            return _obj;
//        }


//        //************************************ XÓA DATA VƠI TÊN ********************************************************
//        //public async Task<Input> DeleteWithName(string name)
//        //{
//        //    var _obj = await _context.Inputs.Where(o => o.Mainput == name).FirstOrDefaultAsync();

//        //    if (_obj != null)
//        //    {
//        //        _context.Inputs.Remove(_obj);

//        //        await _context.SaveChangesAsync();
//        //    }
//        //    return _obj;
//        //}
//        //************************************************************************************************************
//        public async Task<OutputInfo> UpdateAsync(int id, OutputInfo resource)
//        {
//            var _obj = await _context.OutputsInfo.Where(o => o.Mapxinfo == id).FirstOrDefaultAsync();

//            if (_obj != null)
//            {
//                _obj.Mapxinfo = resource.Mapxinfo;


//                await _context.SaveChangesAsync();
//            }
//            return _obj;
//        }
//    }
//}
