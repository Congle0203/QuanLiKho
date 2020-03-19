using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.API.Helper;
using Web.API.Repositories;
using Web.API.Repository;
using Web.API.Resources;

namespace Web.API.Controllers
{
    [Route("/api/[controller]")]
    public class OutputsController : Controller
    {

        private readonly IOutputRepository _outputRepository;


        public OutputsController(IOutputRepository outputRepository)
        {
            _outputRepository = outputRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Output>> GetAllAsync()
        {
            var outputs = await _outputRepository.ListAsync();
            return outputs;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
        {
            PagedList<OutputsItemViewModel> paged = await _outputRepository.GetAllPagingAsync(pagingParams);

            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

            return Ok(paged);
        }




        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Output resource)
        {

            var result = await _outputRepository.SaveAsync(resource);


            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _outputRepository.DeleteAsync(id);


            return Ok(result);
        }

        [HttpDelete("DeleteWithName")]
        public async Task<IActionResult> DeleteWithName([FromBody] Output resource)
        {
            var result = await _outputRepository.DeleteWithName(resource.Tenpx);


            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Output resource)
        {

            var result = await _outputRepository.UpdateAsync(id, resource);


            return Ok(result);
        }
    }

}