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

//    [Route("/api/[controller]")]
//    public class InputsInfoController : Controller
//    {
//        private readonly IInputInfoRepository _inputinfoRepository;

//        public InputsInfoController(IInputInfoRepository inputinfoRepository)
//        {
//            _inputinfoRepository = inputinfoRepository;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<InputInfo>> GetAllAsync()
//        {
//            var inputinfo = await _inputinfoRepository.ListAsync();
//            return inputinfo;
//        }

//        [HttpGet("getAllPaging")]
//        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
//        {
//            PagedList<InputInfo> paged = await _inputinfoRepository.GetAllPagingAsync(pagingParams);

//            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

//            return Ok(paged);
//        }



//        [HttpPost]
//        public async Task<IActionResult> PostAsync([FromBody] InputInfo resource)
//        {

//            var result = await _inputinfoRepository.SaveAsync(resource);


//            return Ok(result);

//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAsync(int id)
//        {
//            var result = await _inputinfoRepository.DeleteAsync(id);


//            return Ok(result);
//        }

//        //[HttpDelete("DeleteWithName")]
//        //public async Task<IActionResult> DeleteWithName([FromBody] InputInfo resource)
//        //{
//        //    var result = await _inputinfoRepository.DeleteWithName(resource.Tenpn);


//        //    return Ok(result);
//        //}

//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutAsync(int id, [FromBody] InputInfo resource)
//        {

//            var result = await _inputinfoRepository.UpdateAsync(id, resource);


//            return Ok(result);
//        }
//    }
//}