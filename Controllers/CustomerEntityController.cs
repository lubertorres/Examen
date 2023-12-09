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




        [HttpGet]
        [Route("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {

            try
            {
                var response = await _customerEntity.GetAllCustomers();
                if (response.Count >= 1)
                {
                    return Ok(response);

                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "No hay resultados" });
            }

        }

        [HttpGet]
        [Route("GetCustomerById")]
        public async Task<IActionResult> GetCustomerById(Guid customerId)
        {
            try
            {
                var response = await _customerEntity.GetCustomerById(customerId);
                if (response.Count >= 1)
                {
                return Ok(response);

                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                return BadRequest(new { Exception = "No hay resultados" });
            }
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




        [HttpPut("EditGlobalCliente")]
        public async Task<IActionResult> EditGlobalCliente(EditCustomerDto editCustomerDto)
        {
            try
            {
                var res = await _customerEntity.EditGlobalCliente(editCustomerDto);
                return Ok(res);
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
