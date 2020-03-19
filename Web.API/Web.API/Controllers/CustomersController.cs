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
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;


        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _customerRepository.ListAsync();
            return customers;
        }

        [HttpGet("getAllPaging")]
        public async Task<IActionResult> GetAllPaging([FromQuery]PagingParams pagingParams)
        {
            PagedList<Customer> paged = await _customerRepository.GetAllPagingAsync(pagingParams);

            Response.AddPagination(paged.CurrentPage, paged.PageSize, paged.TotalCount, paged.TotalPages);

            return Ok(paged);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Customer resource)
        {

            var result = await _customerRepository.SaveAsync(resource);


            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _customerRepository.DeleteAsync(id);


            return Ok(result);
        }

        [HttpDelete("DeleteWithName")]
        public async Task<IActionResult> DeleteWithName([FromBody] Customer resource)
        {
            var result = await _customerRepository.DeleteWithName(resource.Tenkh);


            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Customer resource)
        {

            var result = await _customerRepository.UpdateAsync(id, resource);


            return Ok(result);
        }
    }


}
