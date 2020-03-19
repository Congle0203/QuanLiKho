using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.API.Helper;
using Web.API.Repositories;
using Web.API.Repository;

namespace Web.API.Controllers
{
    [Route("/api/[controller]")]
    public class SuppliersController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetAllAsync()
        {
            var suppliers = await _supplierRepository.ListAsync();
            return suppliers;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
        {
            PagedList<Supplier> paged = await _supplierRepository.GetAllPagingAsync(pagingParams);

            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

            return Ok(paged);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Supplier resource)
        {

            var result = await _supplierRepository.SaveAsync(resource);


            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _supplierRepository.DeleteAsync(id);


            return Ok(result);
        }

        [HttpDelete("DeleteWithName")]
        public async Task<IActionResult> DeleteWithName([FromBody] Supplier resource)
        {
            var result = await _supplierRepository.DeleteWithName(resource.Tenncc);


            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Supplier resource)
        {

            var result = await _supplierRepository.UpdateAsync(id, resource);


            return Ok(result);
        }
    }
}