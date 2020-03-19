//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Web.API.Helper;
//using Web.API.Repository;

//namespace Web.API.Repositories
//{
//    public interface IInputInfoRepository
//    {
//        Task<IEnumerable<InputInfo>> ListAsync();
//        Task<PagedList<InputInfo>> GetAllPagingAsync(PagingParams pagingParams);
//        Task<InputInfo> SaveAsync(InputInfo input);

//        Task<InputInfo> DeleteAsync(int id);

//        //Task<InputInfo> DeleteWithName(string name);

//        Task<InputInfo> UpdateAsync(int id, InputInfo resource);
//    }
//}
