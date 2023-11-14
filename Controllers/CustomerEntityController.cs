using Examen.Dtos;
using Examen.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    public class CustomerEntityController : ControllerBase
    {
        private ICustomerEntity _customerEntity;

        public CustomerEntityController(ICustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;
        }


        [HttpPost]
        [Route("Insertar-Customer")]
        public async Task<IActionResult> InsertarCustomer(CustomerEntityDto customerEntityDto)
        {

            try
            {
                var response = await _customerEntity.InsertarCustomer(customerEntityDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}
