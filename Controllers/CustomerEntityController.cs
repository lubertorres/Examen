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


        [HttpPut]
        [Route("EditarNombreCliente")]
        public async Task<IActionResult> EditarNombreCliente(Guid DocumentNumber, string nombre)
        {

            try
            {
                var response = await _customerEntity.EditarNombreCliente(DocumentNumber, nombre);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpPut]
        [Route("EditarApellidoCliente")]
        public async Task<IActionResult> EditarApellidoCliente(Guid DocumentNumber, string apellido)
        {

            try
            {
                var response = await _customerEntity.EditarApellidoCliente(DocumentNumber, apellido);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpPut]
        [Route("EditarEdadCliente")]
        public async Task<IActionResult> EditarEdadCliente(Guid DocumentNumber, int edad)
        {

            try
            {
                var response = await _customerEntity.EditarEdadCliente(DocumentNumber, edad);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpPut]
        [Route("EditarPhoneCliente")]
        public async Task<IActionResult> EditarPhoneCliente(Guid DocumentNumber, string num)
        {

            try
            {
                var response = await _customerEntity.EditarPhoneCliente(DocumentNumber, num);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }



        [HttpPut]
        [Route("EditarEmailCliente")]
        public async Task<IActionResult> EditarEmailCliente(Guid DocumentNumber, string email)
        {

            try
            {
                var response = await _customerEntity.EditarEmailCliente(DocumentNumber, email);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }




        [HttpPut]
        [Route("EditarEstadoCliente")]
        public async Task<IActionResult> EditarEstadoCliente(Guid DocumentNumber, bool estado)
        {

            try
            {
                var response = await _customerEntity.EditarEstadoCliente(DocumentNumber, estado);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}
