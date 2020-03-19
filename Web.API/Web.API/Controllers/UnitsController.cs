using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Helper;
using Web.API.Repository;

namespace Web.API.Controllers
{
    [Route("/api/[controller]")]
    public class UnitsController : Controller
    {
        private readonly IUnitRepository _unitRepository;

        public UnitsController(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Unit>> GetAllAsync()
        {
            var customers = await _unitRepository.ListAsync();
            return customers;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
        {
            PagedList<Unit> paged = await _unitRepository.GetAllPagingAsync(pagingParams);

            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

            return Ok(paged);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Unit resource)
        {

            var result = await _unitRepository.SaveAsync(resource);


            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _unitRepository.DeleteAsync(id);


            return Ok(result);
        }

        [HttpDelete("DeleteWithName")]
        public async Task<IActionResult> DeleteWithName([FromBody] Unit resource)
        {
            var result = await _unitRepository.DeleteWithName(resource.Tendv);


            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Unit resource)
        {

            var result = await _unitRepository.UpdateAsync(id, resource);


            return Ok(result);
        }
    }


}
