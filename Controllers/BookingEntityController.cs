using Examen.Dtos;
using Examen.Interface;
using Examen.Models;
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
        public async Task<IActionResult> ListarReservasTerror(DateTime fechaInicio, DateTime fechaFin, string genero)
        {
            try
            {
                var response = await _bookinEntity.ListarReservasTerror(fechaInicio, fechaFin, genero);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }




        [HttpGet]
        [Route("Listar-Todas-Las-Reservas-de-un-Usuario")]
        public async Task<IActionResult> GetAllReservasUser(Guid customerId)
        {
            try
            {
                var response = await _bookinEntity.GetAllReservasUser(customerId);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpPut]
        [Route("InactivarButacaReserva")]
        public async Task<IActionResult> InactivarReservaYButaca(Guid bookingId, int seatId)
        {
            try
            {
                var response = await _bookinEntity.InactivarReservaYButaca(bookingId, seatId);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }








        [HttpPut]
        [Route("EditarIdCliente")]
        public async Task<IActionResult> EditarIdCliente(Guid bookingId, Guid DocumentNumber)
        {

            try
            {
                var response = await _bookinEntity.EditarIdCliente(bookingId, DocumentNumber);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpPut]
        [Route("EditarSeatId")]
        public async Task<IActionResult> EditarSeatId(Guid bookingId, int seatId)
        {

            try
            {
                var response = await _bookinEntity.EditarSeatId(bookingId, seatId);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}
