using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using static Web.API.Repository.BaseResposiorty;

namespace Web.API.Repository
{
    public class UnitRepository : BaseRepository, IUnitRepository
    {
        public UnitRepository(AppDbContext context) : base(context)
        {
        }
        //*******************************************************************************************************************
        public async Task<IEnumerable<Unit>> ListAsync()
        {
            return await _context.Units.ToListAsync();
        }

        //*******************************************************************************************************************
        public async Task<PagedList<Unit>> GetAllPagingAsync(PagingParams pagingParams)
        {
            IQueryable<Unit> _query = from u in _context.Units
                                      orderby u.Tendv
                                      select new Unit { Madv = u.Madv, Tendv = u.Tendv, Description  = u.Description };
            //Search all
            if (string.IsNullOrEmpty(pagingParams.Keyword) == false)
            {
                _query = _query.Where(o => o.Tendv.Contains(pagingParams.Keyword) ||
                o.Description.Contains(pagingParams.Keyword));
            }
            //*******************************************************************************************************************
            // Search
            if (pagingParams.SearchValue == "name")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    _query = _query.Where(o => o.Tendv.Contains(pagingParams.SearchKey));
                }
            }

            if (pagingParams.SearchValue == "id")
            {
                if (string.IsNullOrEmpty(pagingParams.SearchKey) == false)
                {
                    int _id = Convert.ToInt32(pagingParams.SearchKey);

                    _query = _query.Where(o => o.Madv == _id);
                }
            }
            //*******************************************************************************************************************
            //Sort 
            if (pagingParams.SortKey == "name")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Tendv);
                else
                    _query = _query.OrderByDescending(o => o.Tendv);
            }

            if (pagingParams.SortKey == "id")
            {
                if (pagingParams.SortValue == "ascend")

                    _query = _query.OrderBy(o => o.Madv);
                else
                    _query = _query.OrderByDescending(o => o.Madv);
            }

            return await PagedList<Unit>
                .CreateAsync(_query, pagingParams.PageNumber, pagingParams.PageSize);
        }
        //*******************************************************************************************************************
        public async Task<Unit> SaveAsync(Unit _obj)
        {
            await _context.Units.AddAsync(_obj);
            await _context.SaveChangesAsync();

            return _obj;

        }

        //*******************************************************************************************************************
        public async Task<Unit> DeleteAsync(int id)
        {
            var _obj = await _context.Units.Where(o => o.Madv == id).FirstOrDefaultAsync();
            if (_obj != null)
            {
                _context.Units.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }


        //*******************************************************************************************************************
        public async Task<Unit> DeleteWithName(string name)
        {
            var _obj = await _context.Units.Where(o => o.Tendv == name).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _context.Units.Remove(_obj);

                await _context.SaveChangesAsync();
            }
            return _obj;
        }

        //*******************************************************************************************************************
        public async Task<Unit> UpdateAsync(int id, Unit resource)
        {
            var _obj = await _context.Units.Where(o => o.Madv == id).FirstOrDefaultAsync();

            if (_obj != null)
            {
                _obj.Tendv = resource.Tendv;
                _obj.Description = resource.Description;
                //_obj.Madv = resource.Madv;


                await _context.SaveChangesAsync();
            }
            return _obj;
        }
    }

}
