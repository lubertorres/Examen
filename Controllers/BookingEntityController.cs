using Examen.Dtos;
using Examen.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    public class BookingEntityController : ControllerBase
    {
        private IBookinEntity _bookinEntity;
        public BookingEntityController(IBookinEntity bookingEntity)
        {
            _bookinEntity = bookingEntity;
        }


        [HttpPost]
        [Route("Insertar-Booking")]
        public async Task<IActionResult> InsertarBooking(BookingEntityDto bookingEntityDto)
        {

            try
            {
                var response = await _bookinEntity.InsertarBooking(bookingEntityDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpGet]
        [Route("Listar-Reservas-Por-Terror-Y-Fecha")]
        public async Task<IActionResult> ListarReservas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                var response = await _bookinEntity.ListarReservas(fechaInicio, fechaFin);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}
