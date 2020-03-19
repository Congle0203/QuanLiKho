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
    public class InputsController : Controller
    {

        private readonly IInputRepository _inputRepository;


        public InputsController(IInputRepository inputRepository)
        {
            _inputRepository = inputRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Input>> GetAllAsync()
        {
            var inputs = await _inputRepository.ListAsync();
            return inputs;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
        {
            PagedList<InputsItemViewModel> paged = await _inputRepository.GetAllPagingAsync(pagingParams);

            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

            return Ok(paged);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Input resource)
        {

            var result = await _inputRepository.SaveAsync(resource);


            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _inputRepository.DeleteAsync(id);


            return Ok(result);
        }

        [HttpDelete("DeleteWithName")]
        public async Task<IActionResult> DeleteWithName([FromBody] Input resource)
        {
            var result = await _inputRepository.DeleteWithName(resource.Tenpn);


            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Input resource)
        {

            var result = await _inputRepository.UpdateAsync(id, resource);


            return Ok(result);
        }
    }


}