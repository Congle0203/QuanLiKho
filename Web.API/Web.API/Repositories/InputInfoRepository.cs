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
//    public class InputInfoRepository : BaseRepository, IInputInfoRepository
//    {
//        public InputInfoRepository(AppDbContext context) : base(context)
//        {
//        }
//        //*************************************************************************************************************
//        public async Task<IEnumerable<InputInfo>> ListAsync()
//        {
//            return await _context.InputsInfo.ToListAsync();
//        }
//        //**************************************************************************************************************
//        public async Task<PagedList<InputInfo>> GetAllPagingAsync(PagingParams pagingParams)
//        {
//            IQueryable<InputInfo> _query = from u in _context.InputsInfo
//                                           orderby u.Mapninfo
//                                           select new InputInfo { Mapninfo = u.Mapninfo, Giavao = u.Giavao, Giaban = u.Giaban, InputId = u.InputId, Soluong = u.Soluong, StockId = u.StockId };

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

//                    _query = _query.Where(o => o.Mapninfo == _id);
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

//                    _query = _query.OrderBy(o => o.Mapninfo);
//                else
//                    _query = _query.OrderByDescending(o => o.Mapninfo);
//            }


//            return await PagedList<InputInfo>
//                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
//        }
//        //************************************** LƯU DATA **********************************************************
//        public async Task<InputInfo> SaveAsync(InputInfo _obj)
//        {
//            await _context.InputsInfo.AddAsync(_obj);
//            await _context.SaveChangesAsync();

//            return _obj;

//        }

//        //************************************ XÓA DATA VƠI ID ********************************************************
//        public async Task<InputInfo> DeleteAsync(int id)
//        {
//            var _obj = await _context.InputsInfo.Where(o => o.Mapninfo == id).FirstOrDefaultAsync();
//            if (_obj != null)
//            {
//                _context.InputsInfo.Remove(_obj);

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
//        public async Task<InputInfo> UpdateAsync(int id, InputInfo resource)
//        {
//            var _obj = await _context.InputsInfo.Where(o => o.Mapninfo == id).FirstOrDefaultAsync();

//            if (_obj != null)
//            {
//                _obj.Mapninfo = resource.Mapninfo;


//                await _context.SaveChangesAsync();
//            }
//            return _obj;
//        }
//    }
//}
