//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Web.API.Helper;
//using Web.API.Repository;

//namespace Web.API.Repositories
//{
//    public interface IOutputInfoRepository
//    {
//        Task<IEnumerable<OutputInfo>> ListAsync();
//        Task<PagedList<OutputInfo>> GetAllPagingAsync(PagingParams pagingParams);
//        Task<OutputInfo> SaveAsync(OutputInfo output);

//        Task<OutputInfo> DeleteAsync(int id);

//        //Task<OutputInfo> DeleteWithName(string name);

//        Task<OutputInfo> UpdateAsync(int id, OutputInfo resource);
//    }
//}
