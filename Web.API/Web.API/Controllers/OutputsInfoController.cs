//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Web.API.Helper;
//using Web.API.Repositories;
//using Web.API.Repository;

//namespace Web.API.Controllers
//{
//    public class OutputsInfoController : Controller
//    {
//        private readonly IOutputInfoRepository _outputinfoRepository;

//        public OutputsInfoController(IOutputInfoRepository outputinfoRepository)
//        {
//            _outputinfoRepository = outputinfoRepository;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<OutputInfo>> GetAllAsync()
//        {
//            var outputsinfo = await _outputinfoRepository.ListAsync();
//            return outputsinfo;
//        }

//        [HttpGet("getAllPaging")]
//        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
//        {
//            PagedList<OutputInfo> paged = await _outputinfoRepository.GetAllPagingAsync(pagingParams);

//            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

//            return Ok(paged);
//        }



//        [HttpPost]
//        public async Task<IActionResult> PostAsync([FromBody] OutputInfo resource)
//        {

//            var result = await _outputinfoRepository.SaveAsync(resource);


//            return Ok(result);

//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            var result = await _outputinfoRepository.DeleteAsync(id);


//            return Ok(result);
//        }

//        //[HttpDelete("DeleteWithName")]
//        //public async Task<IActionResult> DeleteWithName([FromBody] OutputInfo resource)
//        //{
//        //    var result = await _outputinfoRepository.DeleteWithName(resource.Tenpx);


//        //    return Ok(result);
//        //}

//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAsync(int id, [FromBody] OutputInfo resource)
//        {

//            var result = await _outputinfoRepository.UpdateAsync(id, resource);


//            return Ok(result);
//        }
//    }
//}